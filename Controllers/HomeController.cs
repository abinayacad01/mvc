using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using microsoft.data.sqlclient;



namespace mvc.Controllers;

public class HomeController : Controller
{
    SqlConnection con = new sqlConnection();
    SqlConnection com = new sqlCommand();
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

[httpGet]

    public IActionResult Login()
    {
        return View();
    }

    void connectionstring()
    {
        con.connectionstring = "datasource= 192.168.1.240\SQLEXPRESS; database= cad_lw; integrated security=SSPI; TrustServiceCertificate= True;";

    }

    [httpGet]

    public IActionResult verifylogin(loginmodel lmodel)
    {
        connectionstring();
        con.open();
        com.CommandText= "select * from USER_LOGIN where USER_ID = '"+lmodel.username+"' and '"+lmodel.password+"';";

        dr=com.ExecuteReader();
        if(dr.Read()){
            con.Close();
            return View("create");
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


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
