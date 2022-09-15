using Majority.RemittanceProvider.Api.Enums;
using Majority.RemittanceProvider.Application.Features.Commands;
using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Majority.RemittanceProvider.Api.Controllers.V1
{
    [Route("api/v1/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get the transaction status
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>

        [HttpGet("get-transaction-status")]
        public async Task<TransactionStatusDto> GetTransactionStatus([FromQuery] string transactionId)
        {

            var result = await _mediator.Send(new GetTransactionStatusQuery(transactionId));
            HttpContext.Response.StatusCode = (int)Enum.Parse<TransactionStatus>(result.Status);
            return result;
        }

        /// <summary>
        /// Returns a transaction ID.
        /// </summary>
        /// <param name="transactionCommand"></param>
        /// <returns></returns>
        [HttpPost("submit-transaction")]
        public async Task<TransactionStatusDto> SubmitTransaction([FromBody] TransactionCommand transactionCommand)
        {
            //Status
            var result = await _mediator.Send(transactionCommand);
            HttpContext.Response.StatusCode = (int)Enum.Parse<TransactionStatus>(result.Status);
            return result;
        }
    }
}
