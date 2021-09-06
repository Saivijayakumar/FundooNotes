using FundooNotes.Manger.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class LableController : ControllerBase
    {
        private ILableManger lableManger;
        public LableController(ILableManger lableManger)
        {
            this.lableManger = lableManger;
        }

        [HttpPost]
        [Route("api/Add Lable")]
        public IActionResult AddLable([FromBody] LableModel lable)
        {
            try
            {
                string result = this.lableManger.AddLable(lable);
                if (result == "Lable Added Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Add Lable Method",Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/Remove Lable In Note")]
        public IActionResult removeLableInNote(int lableId)
        {
            try
            {
                string result = this.lableManger.removeLableInNote(lableId);
                if (result == "Lable Removed Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Remove Lable Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/Delete Lable")]
        public IActionResult DeleteLable(string lableName)
        {
            try
            {
                string result = this.lableManger.DeleteLable(lableName);
                if (result == "Lable Deleted Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Delete Lable Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/Rename Lable")]
        public IActionResult RenameLable(string updateLableName)
        {
            try
            {
                string result = this.lableManger.RenameLable(updateLableName);
                if (result == "Lable Deleted Successfull")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Delete Lable Method", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Result = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
