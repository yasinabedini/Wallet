using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Wallet.Application.Models.Wallet.Commands.AddWallet;
using Wallet.Application.Models.Wallet.Commands.DepositToWallet;
using Wallet.Application.Models.Wallet.Commands.TransferMoney;
using Wallet.Application.Models.Wallet.Commands.WithdrawFromWallet;

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

        [HttpPost]
        public IActionResult Create(AddWalletCommand command)
        {
            _sender.Send(command);

            return Ok($"A wallet named {command.Title} was created for {command.PhoneNumber}");
        }

        [HttpDelete]
        public IActionResult Delete(DeleteWalletCommand command)
        {
            _sender.Send(command);
            return Ok("Wallet Deleted SuccessFully.");
        }

        [HttpPost("TransferMoney")]
        public IActionResult TransferMoney(TransferMoneyCommand command)
        {
            string message = _sender.Send(command).Result;

            return Ok(message);
        }

        [HttpPost("WithdrawFromWallet")]
        public IActionResult WithdrawFromWallet(WithdrawFromWalletCommand command)
        {
            string message = _sender.Send(command).Result;

            return Ok(message);
        }

        [HttpPost("DepositToWallet")]
        public IActionResult DepositToWallet(DepositToWalletCommand command)
        {
            string message = _sender.Send(command).Result;
            return Ok(message);
        }
    }
}
