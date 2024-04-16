using Application.Transaction.Requests;
using Application.User.Commands;
using Application.User.Queries;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Application.Transaction.Commands;
using Application.Validator;
using Application.Transaction.Response;
using Application.Currency.Queries;
using Application.Transaction.Queries;

namespace Presentation.Controllers 
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase 
    {
        private CreateTransactionCommand CreateTransactionCommand;
        private AddTransactionToUserCommand AddTransactionToUserCommand;
        private HashValidator HashValidator;
        private GetCurrencyQuery GetCurrencyQuery;
        private GetTransactionQuery GetTransactionQuery;
        private GetUserQuery GetUserQuery;
        private UserExistsByIdQuery UserExistsByIdQuery;
        private CurrencyExistsByLabelQuery CurrencyExistsByLabelQuery;
        private readonly ILogger<TransactionController> _logger;
        
        public TransactionController(ILogger<TransactionController> logger, CurrencyExistsByLabelQuery currencyExistsByLabelQuery, UserExistsByIdQuery userExistsByIdQuery, CreateTransactionCommand createTransactionCommand, AddTransactionToUserCommand addTransactionToUserCommand, HashValidator hashValidator, GetCurrencyQuery getCurrencyQuery, GetTransactionQuery getTransactionQuery, GetUserQuery getUserQuery)
        {
            _logger = logger;
            CurrencyExistsByLabelQuery = currencyExistsByLabelQuery;
            UserExistsByIdQuery = userExistsByIdQuery;
            CreateTransactionCommand = createTransactionCommand;
            AddTransactionToUserCommand = addTransactionToUserCommand;
            HashValidator = hashValidator;
            GetCurrencyQuery = getCurrencyQuery;
            GetTransactionQuery = getTransactionQuery;
            GetUserQuery = getUserQuery;
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
            TransactionResponse response = new TransactionResponse();

            try
            {
                if (!UserExistsByIdQuery.UserExistsById(transactionRequest.UserId))
                {
                    response.Status = TransactionStatus.InvalidPlayer;
                    response.Message = "User not found.";
                    return BadRequest(response);
                }

                if (!CurrencyExistsByLabelQuery.currencyExistsByLabel(transactionRequest.Currency))
                {
                    response.Status = TransactionStatus.InvalidCurrency;
                    response.Message = "Currency not found.";
                    return BadRequest(response);
                }

                string validatedHash = HashValidator.ValidateHash(transactionRequest.ExternalTransactionId, transactionRequest.UserId, transactionRequest.Amount, transactionRequest.Currency);
                if (hash != validatedHash)
                {
                    throw new TransactionValidationFailderException();
                }

                response.Status = TransactionStatus.Success;
                response.Message = "Transaction proceed successfully.";
                Currency c = GetCurrencyQuery.GetByLabel(transactionRequest.Currency);
                string? tId = CreateTransactionCommand.Handle(transactionRequest.Amount, c, response.Message, (int)response.Status);
                Transaction t = GetTransactionQuery.GetById(tId!);
                User u = GetUserQuery.GetById(transactionRequest.UserId);
                AddTransactionToUserCommand.AddTransactionToUser(u, t);
                response.TransactionId = tId;

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}