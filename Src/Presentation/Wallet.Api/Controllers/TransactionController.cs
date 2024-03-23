using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Reflection.Metadata.Ecma335;
using Wallet.Application.Models.Transaction.Queries.GetTransaction;
using Wallet.Application.Models.Transaction.Queries.GetTransactions;
using Wallet.Application.Models.Transaction.Queries.GetTransactionsByWalletId;

namespace Wallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ISender _sender;
        private string _ip;

        public TransactionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("GetAllTransaction")]
        public IActionResult GetAll(GetTransactionsQuery query)
        {
            var result =  _sender.Send(query).Result;
            _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            Log.Information($"User with ip ({_ip}) Executed GetAllTransactions");
            return Ok(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(GetTransactionQuery query)
        {
            var result = _sender.Send(query).Result;
            _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            Log.Information($"User with ip ({_ip}) Executed GetById({query.Id})");
            return Ok(result);
        }

        [HttpPost("GetByWalletId")]
        public IActionResult GetByWalletId(GetTransactionsByWalletIdQuery query)
        {
            var result = _sender.Send(query).Result;
            _ip = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            Log.Information($"User with ip ({_ip}) Executed GetByWalletId({query.WalletId})");
            return Ok(result);
        }
    }
}
