using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Models.Wallet.Commands.AddWallet;
using Wallet.Application.Models.Wallet.Commands.CheckWalletAvailability;
using Wallet.Application.Models.Wallet.Commands.CheckWalletBalance;
using Wallet.Application.Models.Wallet.Commands.DepositToWallet;
using Wallet.Application.Models.Wallet.Commands.TransferMoney;
using Wallet.Application.Models.Wallet.Commands.WithdrawFromWallet;
using Wallet.Application.Models.Wallet.Queries.GetWallet;
using Wallet.Application.Models.Wallet.Queries.GetWalletByPhoneNumber;
using Wallet.Application.Models.Wallet.Queries.GetWallets;

namespace Wallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly ISender _sender;

        public WalletController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("GetAll")]
        public IActionResult GetAllWallets([FromBody]GetWalletsQuery query)
        {
            Response.StatusCode = 200;
            Response.ContentType = "application/json";
            return Ok(_sender.Send(query).Result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(GetWalletQuery query)
        {
            Response.StatusCode = 200;
            Response.ContentType = "application/json";
            return Ok(_sender.Send(query).Result);
        }

        [HttpPost("GetWalleyByPhoneNumber")]
        public IActionResult GetWalleyByPhoneNumber(GetWalletByPhoneNumberQuery query)
        {
            Response.StatusCode = 200;
            Response.ContentType = "application/json";
            return Ok(_sender.Send(query).Result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddWalletCommand command)
        {
            _sender.Send(command);

            return Ok($"A wallet named {command.Title} was created for {command.PhoneNumber}");
        }

        [HttpDelete]
        public  IActionResult Delete([FromBody] DeleteWalletCommand command)
        {
            if (!_sender.Send(new CheckWalletAvailabilityCommand(command.WalletId)).Result)
            {
                return NotFound();
            }

            _sender.Send(command);
            return Ok("Wallet Deleted SuccessFully.");
        }

        [HttpPost("TransferMoney")]
        public IActionResult TransferMoney([FromBody] TransferMoneyCommand command)
        {
            if (!_sender.Send(new CheckWalletAvailabilityCommand(command.SourceWalletId)).Result|| !_sender.Send(new CheckWalletAvailabilityCommand(command.DestinationWalletId)).Result)
            {
                return NotFound();
            }

            if (!_sender.Send(new CheckWalletBalanceCommand(command.SourceWalletId,command.Amount)).Result)
            {
                Response.StatusCode = 406;                
                return Content("Source wallet has no balance");
            }

            string message = _sender.Send(command).Result;

            return Ok(message);
        }

        [HttpPost("WithdrawFromWallet")]
        public IActionResult WithdrawFromWallet([FromBody]WithdrawFromWalletCommand command)
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

            string message = _sender.Send(command).Result;

            return Ok(message);
        }

        [HttpPost("DepositToWallet")]
        public IActionResult DepositToWallet([FromBody] DepositToWalletCommand command)
        {
            if (!_sender.Send(new CheckWalletAvailabilityCommand(command.WalletId)).Result)
            {
                return NotFound();
            }

            string message = _sender.Send(command).Result;
            return Ok(message);
        }
    }
}
