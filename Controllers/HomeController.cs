using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Microsoft.Data.SqlClient;

namespace mvc.Controllers;

public class HomeController : Controller
{
    SqlConnection con=new SqlConnection();
    SqlCommand com= new SqlCommand();

    SqlDataReader? dr;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Home()
    {
        return View();
    }

   public IActionResult Tutorials()
    {
        return View();
    } 
    public IActionResult Testpage()
    {
        return View();
    } 
    public IActionResult Paidcourses()
    {
        return View();
    } 

[HttpGet]

    public IActionResult Login()
    {
        return View();
    }

    void ConnectionString()
    {
        con.ConnectionString = "data source= 192.168.1.240\\SQLEXPRESS; database= cad_lw; user ID= CADBATCH01; password=CAD@123pass; TrustServerCertificate= True;";

    }

    [HttpPost]

    public IActionResult verifyLogin(LoginModel lmodel)
    {
        ConnectionString();
        con.Open();
        com.Connection=con; 
        com.CommandText= "select * from USER_LOGIN where username ='"+lmodel.username+"' and password ='"+lmodel.password+"';";

        dr=com.ExecuteReader();
        if(dr.Read()){
            con.Close();
            return View("Create");
        }
        else{
            con.Close();
            return View("error");
        }
        
    }
        public IActionResult AboutUs()
    {
        return View();
    }
    [HttpGet]
        public IActionResult Register()
    {
        return View();
    }
     void conStr(){
         con.ConnectionString="data source=192.168.1.240\\SQLEXPRESS; database=CAD_LW; User ID=CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True; ";
    }
    
    [HttpPost]
     public IActionResult RegisterDB(RegisterModel rmodel)
    {   

         conStr();
         con.Open();
         SqlCommand cmd = new SqlCommand();
         cmd.Connection=con;
         cmd.CommandText="INSERT INTO USR_REG (USERNAME, EMAIL_ID, USER_ID,PASSWORD,CONFIRM_PASSWORD)VALUES (@USERNAME, @EMAIL_ID, @USER_ID, @PASSWORD, @CONFIRM_PASSWORD);";
          
          cmd.Parameters.AddWithValue("@USERNAME", rmodel.USERNAME);
          cmd.Parameters.AddWithValue("@EMAIL_ID", rmodel.EMAIL_ID);
          cmd.Parameters.AddWithValue("@USER_ID", rmodel.USER_ID);
          cmd.Parameters.AddWithValue("@PASSWORD", rmodel.PASSWORD);
          cmd.Parameters.AddWithValue("@CONFIRM_PASSWORD", rmodel.CONFIRM_PASSWORD);
         
         int rowAffected=cmd.ExecuteNonQuery();
         if(rowAffected>0){
             return RedirectToAction("Login");
         }
         else{

             return RedirectToAction("Error");
         }
        return View();
        
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
