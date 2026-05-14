using Common;
using EMS.API.AppCode.Enum;
using EMS.API.AppCode.Extensions;
using EMS.BUSINESS.Dtos.AD;
using EMS.BUSINESS.Dtos.MD;
using EMS.BUSINESS.Services.AD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.AD
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountStoreController(IAccountStoreService _Service) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] BaseMdFilter filter)
        {
            var transferObject = new TransferObject();
            try
            {
                var result = await _Service.GetAll(filter);
                transferObject.Data = result;
            }
            catch (Exception ex)
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("2000", _Service);
            }
            return Ok(transferObject);
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] BaseFilter filter)
        {
            var transferObject = new TransferObject();
            try
            {
                var result = await _Service.Search(filter);
                transferObject.Data = result;
            }
            catch (Exception ex)
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("2000", _Service);

            }
            return Ok(transferObject);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] AccountStoreDto data)
        {
            var transferObject = new TransferObject();
            var result = await _Service.Add(data);
            try
            {               
                transferObject.Data = result;
            }
            catch (Exception ex)
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("2000", _Service);
            }
            return Ok(transferObject);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] AccountStoreDto data)
        {
            var transferObject = new TransferObject();
            await _Service.Update(data);
            try
            {               
                transferObject.Status = true;
                transferObject.MessageObject.MessageType = MessageType.Success;
                transferObject.GetMessage("0103", _Service);
            }
            catch (Exception ex)
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("2000", _Service);

            }
            return Ok(transferObject);
        }

        [HttpDelete("Delete/{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            var transferObject = new TransferObject();
            await _Service.Delete(username);
            if (_Service.Status)
            {
                transferObject.Status = true;
                transferObject.MessageObject.MessageType = MessageType.Success;
                transferObject.GetMessage("0105", _Service);
            }
            else
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("0106", _Service);
            }
            return Ok(transferObject);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] createAccountStoreDto createAccountStoreDto)
        {
            var transferObject = new TransferObject();
            var result = await _Service.Create(createAccountStoreDto);
            try
            {              
                transferObject.Data = result;
            }
            catch (Exception ex)
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("2000", _Service);
            }
            return Ok(transferObject);
        }

        [HttpGet("GetAllAccount")]
        public async Task<IActionResult> GetAllAccount([FromQuery] BaseMdFilter filter)
        {
            var transferObject = new TransferObject();
            var result = await _Service.GetAllAccount(filter);
            try
            {               
                transferObject.Data = result;
            }
            catch (Exception ex)
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("2000", _Service);
            }
            return Ok(transferObject);
        }

        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] updateAccountStoreDto data)
        {
            var transferObject = new TransferObject();
            await _Service.UpdateAccount(data);
            try
            {              
                transferObject.Status = true;
                transferObject.MessageObject.MessageType = MessageType.Success;
                transferObject.GetMessage("0103", _Service);
            }
            catch (Exception ex)
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("2000", _Service);

            }
            return Ok(transferObject);
        }
    }
}
