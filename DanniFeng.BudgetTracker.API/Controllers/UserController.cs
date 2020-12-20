using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanniFeng.BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IIncomeService _incomeService;
        private readonly IExpenditureService _expenditureService;
        public UsersController(IUserService userService, IIncomeService incomeService, IExpenditureService expenditureService)
        {
            _userService = userService;
            _incomeService = incomeService;
            _expenditureService = expenditureService;
        }

        

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAccountDetail(int id)
        {
            var accountDetail = await _userService.GetAccountDetailById(id);
            return Ok(accountDetail);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateUser(UserRequestModel userRequestModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUser(userRequestModel);
                return Ok(userRequestModel);
            }
            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPut("{id:int}/update")]
        public async Task<ActionResult> UpdateUser(UserRequestModel userRequestModel, int id)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUser(userRequestModel, id);
                return Ok(userRequestModel);
            }
            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpDelete("delete/{userId:int}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUser(userId);
            return NoContent();
        }

        [HttpPost]
        [Route("{id:int}/income")]
        public async Task<IActionResult> AddIncome(IncomeRequestModel incomeRequestModel, int id)
        {
            if (ModelState.IsValid)
            {
                await _incomeService.AddIncome(incomeRequestModel, id);
                return Ok(incomeRequestModel);
            }
            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPut("{uid:int}/incomeupdate/{incomeid:int}")]
        public async Task<ActionResult> UpdateIncome(IncomeRequestModel incomeRequestModel, int uid, int incomeid)
        {
            if (ModelState.IsValid)
            {
                await _incomeService.UpdateIncome(incomeRequestModel, uid, incomeid);
                return Ok(incomeRequestModel);
            }
            return BadRequest(new { message = "please correct the input information" });
        }


        [HttpDelete("{userId:int}/income/{incomeId:int}")]
        public async Task<ActionResult> DeleteIncome(int incomeId)
        {
            await _incomeService.DeleteIncome(incomeId);
            return NoContent();
        }

        [HttpPost]
        [Route("{id:int}/expenditure")]
        public async Task<IActionResult> AddExpenditure(ExpenditureRequestModel expenditureRequestModel, int id)
        {
            if (ModelState.IsValid)
            {
                await _expenditureService.AddExpenditure(expenditureRequestModel, id);
                return Ok(expenditureRequestModel);
            }
            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPut("{uid:int}/expenditureupdate/{expenditureid:int}")]
        public async Task<ActionResult> UpdateExpenditure(ExpenditureRequestModel expenditureRequestModel, int uid, int expenditureid)
        {
            if (ModelState.IsValid)
            {
                await _expenditureService.UpdateExpenditure(expenditureRequestModel, uid, expenditureid);
                return Ok(expenditureRequestModel);
            }
            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpDelete("{userId:int}/expenditure/{expenditureId:int}")]
        public async Task<ActionResult> DeleteExpenditure(int expenditureId)
        {
            await _expenditureService.DeleteExpenditure(expenditureId);
            return NoContent();
        }

        [HttpGet]
        [Route("userlist")]
        public async Task<IActionResult> GetAllUsersDetail()
        {
            var users = await _userService.GetAllUsers();
            if (!users.Any())
            {
                return NoContent();
            }
            return Ok(users);
        }
    }
}
