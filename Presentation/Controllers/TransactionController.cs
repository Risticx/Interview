using Application.Transaction.Requests;
using Application.User.Commands;
using Application.User.Queries;
using System.Security.Cryptography;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Application.Transaction.Commands;
using Application.Validator;
using Application.Transaction.Response;

namespace Presentation.Controllers 
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase 
    {
        private CreateTransactionCommand CreateTransactionCommand;
        private HashValidator HashValidator;
        
        public TransactionController(CreateTransactionCommand createTransactionCommand, HashValidator hashValidator)
        {
            CreateTransactionCommand = createTransactionCommand;
            HashValidator = hashValidator;
        }

        [Route("/createHash")]
        [HttpPost]
        public ActionResult CreateHash([FromBody] TransactionRequest transactionRequest)
        {
            return Ok(HashValidator.ValidateHash(transactionRequest.ExternalTransactionId, transactionRequest.UserId, transactionRequest.Amount, transactionRequest.Currency));
        }


        [Route("/createTransaction")]
        [HttpPost]
        public ActionResult<TransactionResponse> CreateTransaction([FromBody] TransactionRequest transactionRequest, [FromHeader(Name = "Hash")] string hash)
        {
            string validatedHash = HashValidator.ValidateHash(transactionRequest.ExternalTransactionId, transactionRequest.UserId, transactionRequest.Amount, transactionRequest.Currency);
            if(hash != validatedHash) 
            {
                return BadRequest("Hash validation failed.");
            }
            else
            {
                string? tId = CreateTransactionCommand.Handle(transactionRequest.Amount, "Aa", transactionRequest.Currency, 0);
                TransactionResponse r = new TransactionResponse(tId!, "Aa", 0);
                return Ok(r);
            }

        }
    }

}