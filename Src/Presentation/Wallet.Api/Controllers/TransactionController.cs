using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public TransactionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("GetAllTransaction")]
        public IActionResult GetAll(GetTransactionsQuery query)
        {
            var result =  _sender.Send(query).Result;

            return Ok(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(GetTransactionQuery query)
        {
            var result = _sender.Send(query).Result;

            return Ok(result);
        }

        [HttpPost("GetByWalletId")]
        public IActionResult GetByWalletId(GetTransactionsByWalletIdQuery query)
        {
            var result = _sender.Send(query).Result;

            return Ok(result);
        }
    }
}
