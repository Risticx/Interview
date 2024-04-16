using Application.Currency.Commands;
using Application.Currency.Queries;
using Application.User.Commands;
using Application.User.Queries;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers 
{
    [Route("api/currency")]
    [ApiController]
    public class CurrencyController : ControllerBase 
    {
        private GetCurrencyQuery GetCurrencyQuery;
        private CreateCurrencyCommand CreateCurrencyCommand;

        public CurrencyController(GetCurrencyQuery getCurrencyQuery, CreateCurrencyCommand createCurrencyCommand)
        {
            GetCurrencyQuery = getCurrencyQuery;
            CreateCurrencyCommand = createCurrencyCommand;
        }

        [Route("{label}")]
        [HttpGet]
        public ActionResult GetCurrency(string label)
        {
            try {
                return Ok(GetCurrencyQuery.GetByLabel(label));
            } catch (CurrencyNotFoundException e) {
                return NotFound(e.Message);
            }
        }

        [Route("{label}")]
        [HttpPost]
        public ActionResult<Currency> CreateCurrency(string label)
        {
            try {
                CreateCurrencyCommand.Handle(label);
            } catch (CurrencyExistsByLabelException e) {
                return NotFound(e.Message);
            }

            return Ok("Currency created successfully.");
        }
    }

}