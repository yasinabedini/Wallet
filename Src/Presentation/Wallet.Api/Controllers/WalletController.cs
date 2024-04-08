using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Wallet.Application.Models.Wallet.Commands.AddWallet;
using Wallet.Application.Models.Wallet.Commands.BuyMobileRecharge;
using Wallet.Application.Models.Wallet.Commands.CheckWalletAvailability;
using Wallet.Application.Models.Wallet.Commands.CheckWalletBalance;
using Wallet.Application.Models.Wallet.Commands.DeleteWallet;
using Wallet.Application.Models.Wallet.Commands.PayingBill;
using Wallet.Application.Models.Wallet.Commands.ProductPurchase;
using Wallet.Application.Models.Wallet.Commands.RechargeWallet;
using Wallet.Application.Models.Wallet.Commands.TransferMoney;
using Wallet.Application.Models.Wallet.Commands.WithdrawFromWallet;
using Wallet.Application.Models.Wallet.Queries.GetWallet;
using Wallet.Application.Models.Wallet.Queries.GetWalletByPhoneNumber;
using Wallet.Application.Models.Wallet.Queries.GetWallets;

namespace Wallet.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WalletController : ControllerBase
{
    private readonly ISender _sender;
    private string _ip;

    public WalletController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("GetAll")]
    public IActionResult GetAllWallets([FromBody] GetWalletsQuery query)
    {
        Response.StatusCode = 200;
        Response.ContentType = "application/json";
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed GetAllWallets");
        return Ok(_sender.Send(query).Result);
    }

    [HttpPost("GetById")]
    public IActionResult GetById(GetWalletQuery query)
    {
        Response.StatusCode = 200;
        Response.ContentType = "application/json";
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed GetById({query.Id})");
        return Ok(_sender.Send(query).Result);
    }

    [HttpPost("GetWalleyByPhoneNumber")]
    public IActionResult GetWalleyByPhoneNumber(GetWalletByPhoneNumberQuery query)
    {
        Response.StatusCode = 200;
        Response.ContentType = "application/json";
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed GetWalleyByPhoneNumber({query.PhoneNumber})");
        return Ok(_sender.Send(query).Result);
    }

    [HttpPost("CreateWallet")]
    public IActionResult Create([FromBody] AddWalletCommand command)
    {
        _sender.Send(command);
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed Create And Create Wallet");
        return Ok($"A wallet named {command.Title} was created for {command.PhoneNumber}");
    }

    [HttpDelete("Delete")]
    public IActionResult Delete([FromBody] DeleteWalletCommand command)
    {
        if (!_sender.Send(new CheckWalletAvailabilityCommand(command.WalletId)).Result)
        {
            return NotFound();
        }

        _sender.Send(command);
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed Delete({command.WalletId})");
        return Ok("Wallet Deleted SuccessFully.");
    }

    [HttpPost("TransferMoney")]
    public IActionResult TransferMoney([FromBody] TransferMoneyCommand command)
    {
        if (!_sender.Send(new CheckWalletAvailabilityCommand(command.SourceWalletId)).Result || !command.DestinationWallets.All(t => _sender.Send(new CheckWalletAvailabilityCommand(t.Item1)).Result))
        {
            Response.StatusCode = 404;
            return Content("You entered the wrong ID of one of the destinations wallets or source wallet.");
        }

        if (!_sender.Send(new CheckWalletBalanceCommand(command.SourceWalletId, command.DestinationWallets.Sum(t => t.Item2))).Result)
        {
            Response.StatusCode = 406;
            return Content("Source wallet has no balance");
        }

        string message = _sender.Send(command).Result;
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed Transafer and transafer Money");
        return Ok(message);
    }

    [HttpPost("WithdrawFromWallet")]
    public IActionResult WithdrawFromWallet([FromBody] WithdrawFromWalletCommand command)
    {
        if (!_sender.Send(new CheckWalletAvailabilityCommand(command.WalletId)).Result)
        {
            return NotFound();
        }

        if (!_sender.Send(new CheckWalletBalanceCommand(command.WalletId, command.Amount)).Result)
        {
            Response.StatusCode = 406;
            return Content("Your wallet has no balance");
        }
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed WithdrawFromWallet({command.WalletId})");
        string message = _sender.Send(command).Result;

        return Ok(message);
    }

    [HttpPost("RechargeWallet")]
    public IActionResult RechargeWallet([FromBody] RechargeWalletCommand command)
    {
        if (!_sender.Send(new CheckWalletAvailabilityCommand(command.WalletId)).Result)
        {
            return NotFound();
        }
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed RechargeWallet({command.WalletId})");
        string message = _sender.Send(command).Result;
        return Ok(message);
    }

    [HttpPost("PayingBill")]
    public IActionResult PayingBill([FromBody] PayingBillCommand command)
    {
        if (!_sender.Send(new CheckWalletAvailabilityCommand(command.WalletId)).Result)
        {
            return NotFound();
        }

        if (!_sender.Send(new CheckWalletBalanceCommand(command.WalletId, command.BillAmount)).Result)
        {
            Response.StatusCode = 406;
            return Content("Your wallet has no balance");
        }
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed PayingBill({command.WalletId})");
        string message = _sender.Send(command).Result;
        return Ok(message);
    }

    [HttpPost("ProductPurchase")]
    public IActionResult ProductPurchase([FromBody] ProductPurchaseCommand command)
    {
        if (!_sender.Send(new CheckWalletAvailabilityCommand(command.WalletId)).Result)
        {
            return NotFound();
        }

        if (!_sender.Send(new CheckWalletBalanceCommand(command.WalletId, command.Amount)).Result)
        {
            Response.StatusCode = 406;
            return Content("Your wallet has no balance");
        }
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed ProductPurchase({command.WalletId})");
        string message = _sender.Send(command).Result;
        return Ok(message);
    }

    [HttpPost("BuyMobileRecharge")]
    public IActionResult BuyMobileRecharge([FromBody] BuyMobileRechargeCommand command)
    {
        if (!_sender.Send(new CheckWalletAvailabilityCommand(command.WalletId)).Result)
        {
            return NotFound();
        }

        if (!_sender.Send(new CheckWalletBalanceCommand(command.WalletId, command.RechargeAmount)).Result)
        {
            Response.StatusCode = 406;
            return Content("Your wallet has no balance");
        }
        _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        Log.Information($"User with ip ({_ip}) Executed BuyMobileRecharge({command.WalletId})");
        string message = _sender.Send(command).Result;
        return Ok(message);
    }
}
