using Common;
using EMS.API.AppCode.Enum;
using EMS.API.AppCode.Extensions;
using EMS.BUSINESS.Dtos.MD;
using EMS.BUSINESS.Services.MD;
using Microsoft.AspNetCore.Mvc;


namespace EMS.API.Controllers.MD
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountTypeController(IAccountTypeService Service) : ControllerBase
    {
        private readonly IAccountTypeService _service = Service;

        
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] BaseFilter filter)
        {
            var transferObject = new TransferObject();
            var result = await _service.Search(filter);
            try
            {
                transferObject.Data = result;
            }
            catch (Exception ex)
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("2000", _service);

            }
            return Ok(transferObject);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] AccountTypeDto data)
        {
            var transferObject = new TransferObject();
            var result = await _service.Add(data);
            try
            {
                transferObject.Data = result;
            }
            catch (Exception ex)
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("2000", _service);
            }
            return Ok(transferObject);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] AccountTypeDto data)
        {
            var transferObject = new TransferObject();
            var result = await _service.Update(data);
            if (_service.Status)
            {
                transferObject.Status = true;
                transferObject.MessageObject.MessageType = MessageType.Success;
                transferObject.GetMessage("0103", _service);
            }
            else
            {
                transferObject.Status = false;
                transferObject.MessageObject.MessageType = MessageType.Error;
                transferObject.GetMessage("0104", _service);
            }
            return Ok(transferObject);
        }


    }
}
