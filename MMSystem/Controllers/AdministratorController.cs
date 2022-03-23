using Microsoft.AspNetCore.Mvc;
using MMSystem.Model;
using MMSystem.Model.ViewModel;
using MMSystem.Services;
using MMSystem.Services.Histor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]


    public class AdministratorController : ControllerBase
    {


        public AdministratorController(IAdministratorInterface Users,IHistory hstory)
        {
            _data = Users;
            _hstory = hstory;
        
        }
        private readonly IAdministratorInterface _data;

        private readonly IHistory _hstory;
 

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Administrator>>> GetAllUsers()
        {
            var users = await _data.GetAll();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();

            }
        }


        [HttpGet]
        [Route("GetPageintoin")]
        public async Task<ActionResult<PageintoinAdmin>> GetAllAdministrator(int page, int pageSize)
        {
            var users = await _data.GetAdministrator(page, pageSize);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();

            }
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _data.Get(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound(new Result() {  message= "المستخدم غير موجود", statusCode= 404});

            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAdministrator([FromBody] UserAddORUpdate newuservalue)
        {
            Historyes historyes = new Historyes();
            var olduservalue = await _data.Get(newuservalue.Administrator.UserId);
            
            historyes.changes = "  ";
            if (newuservalue.Administrator.userNetwork != olduservalue.Administrator.userNetwork)
            {
                historyes.changes = historyes.changes + "\n \t" + "  تم تغيير الاسم علي الشبكة  " + olduservalue.Administrator.userNetwork + "  إلي  " + newuservalue.Administrator.userNetwork;
            }
            if (newuservalue.Administrator.UserName != olduservalue.Administrator.UserName) {
                historyes.changes = historyes.changes + "\n \t" + "   تم تغيير اسم المستخدم من   " + olduservalue.Administrator.UserName + "  إلي  " + newuservalue.Administrator.UserName;
            }
            if (!(newuservalue.Administrator.password == olduservalue.Administrator.password))
            {
                historyes.changes = historyes.changes + "\n \t" + "    تم تغيير  كلمة المرور    ";
            }
            if (newuservalue.Administrator.nationalNumber != olduservalue.Administrator.nationalNumber)
            {
                historyes.changes = historyes.changes + "\n \t" + "   تم تغيير الرقم الوطني من  " + olduservalue.Administrator.nationalNumber + "  إلي  " + newuservalue.Administrator.nationalNumber ;

            }
          
            if (newuservalue.Administrator.DepartmentId != olduservalue.Administrator.DepartmentId)
            {
                historyes.changes= historyes.changes + "\n \t" + "   تم تغيير رقم الادارة من  " + olduservalue.Administrator.DepartmentId + "  إلي  " + newuservalue.Administrator.DepartmentId ;

            }
            if (newuservalue.Administrator.state != olduservalue.Administrator.state)
            {
                if (newuservalue.Administrator.state)
                {
                    historyes.changes = historyes.changes + "\n \t" + "   تم تغييرالحالة من  غير مفعل  " + " إلي " + "  مفعل   ";
                }
                else { 
                historyes.changes = historyes.changes + "\n \t" + "   تم تغييرالحالة من   مفعل  " + " إلي " + "  غير مفعل  ";
                }
            }

            List<int>  newrole = newuservalue.Listrole;
            List<int>  oldrole = await _data.GetJustRole(newuservalue.Administrator.UserId);
             
            string Stringnewrole = string.Join(",", newrole);
            string Stringoldrole = string.Join(",", oldrole);
            if (!Stringnewrole.Equals(Stringoldrole)) {
           
                historyes.changes = historyes.changes + "\n \t" + "  تم تغيير الصلاحيات من " + Stringoldrole + "  إلي  " + Stringnewrole;
            }

            bool results = await _data.Update(newuservalue);

            historyes.currentUser = newuservalue.currentUser;
            historyes.Time = System.DateTime.Now;
            historyes.HistortyNameID = 11;

            if (results)
            {
                await _hstory.Add(historyes);
                return Ok(new Result() { message = "تمت عملية التحديث ", statusCode = 200 });
            }
            return StatusCode(304, new Result() { message = "لم تتم عملية التحديث ", statusCode = 304 });
        }

        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAdministrator([FromBody] StopActive stopactive)
        {
            var user = await _data.Get(stopactive.UserId);
            Historyes historyes = new Historyes();
            if (user.Administrator.state == true)
            {
                historyes.changes = historyes.changes + "تم تغيير الحالة من  مفعل   " + "  إلي  " + " غير مفعل ";
               
            }
            else
            {
                historyes.changes = historyes.changes + "تم تغيير الحالة من  غير مفعل  " + "  إلي  " + " مفعل ";
            }
            bool results = await _data.Delete(stopactive.UserId);
         
            historyes.currentUser = stopactive.currentUser;
            historyes.Time = System.DateTime.Now;
            historyes.HistortyNameID = 12;
          
          
            if (results)
            {
                
                await _hstory.Add(historyes);
                return Accepted(new Result() { message = "نجحت العملية", statusCode = 202 });
            }

            return NotFound(new Result() { message = "هذا المستخدم غير موجود", statusCode = 404 });

        }

        [HttpPost]
        [Route("Add")]

        public async Task<IActionResult> AddAdministrator([FromBody] UserAddORUpdate user)
        {
        
            user.Administrator.password = BCrypt.Net.BCrypt.HashPassword(user.Administrator.password);

            bool results = await _data.Add(user);

            Historyes historyes = new Historyes();
            historyes.currentUser = user.currentUser;
            historyes.Time = System.DateTime.Now;
            historyes.HistortyNameID = 10;
            historyes.changes = "تم إضافة مستخدم جديد";
            if (results)
            {
                await _hstory.Add(historyes);
                return Created("AddAdministrator", new Result() { message = "تمت عملية الاضافة بنجاح", statusCode = 201 });
            }
                 return BadRequest(new Result() { message = "قشل في عملية الاضافة  ", statusCode = 400 }); 

              }


        [HttpGet]
        [Route("GetByDepartmentId")]
        public async Task<ActionResult<List<Administrator>>> GetByDepartmentId(int department)
        {
            var users = await _data.SearchByDepartmentId(department);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound(new Result() { message = "لايوجد مستخدم في هذه الإدارة  ", statusCode = 400 });

            }
        }
        [HttpGet]
        [Route("GetByDepartmentIdControl")]
        public async Task<ActionResult<List<Administrator>>> GetByDepartmentIdControl(int department)
        {
            var users = await _data.SearchByDepartmentIdControl(department);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound(new Result() { message = "لايوجد مستخدم في هذه الإدارة  ", statusCode = 400 });

            }
        }

        [HttpGet]
        [Route("GetByUserName")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            var users = await _data.SearchByName(username);
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound(new Result() { message = "لايوجد مستخدم بهذا الاسم", statusCode = 400 });

            }
        }

    }
}
