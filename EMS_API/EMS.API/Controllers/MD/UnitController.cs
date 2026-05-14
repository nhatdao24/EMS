using Common;
using EMS.API.AppCode.Enum;
using EMS.API.AppCode.Extensions;
using EMS.BUSINESS.Dtos.MD;
using EMS.BUSINESS.Filter.AD;
using EMS.BUSINESS.Services.MD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers.MD
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController(IUnitService Service) : ControllerBase
    {
        private readonly IUnitService _Service = Service;
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] BaseMdFilter filter)
        {
            var transferObject = new TransferObject();
            var result = await _Service.GetAll(filter);
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
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] BaseFilter filter)
        {
            var transferObject = new TransferObject();
            var result = await _Service.Search(filter);
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

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] UnitDto data)
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
        public async Task<IActionResult> Update([FromBody] UnitDto data)
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

        [HttpDelete("Delete/{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var transferObject = new TransferObject();
            await _Service.Delete(code);
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
    }

}
