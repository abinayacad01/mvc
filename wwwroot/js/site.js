
function togglepassword(){
    var passwordInput = document.getElementById("password");
    var toggleCheckbox = document.getElementById("showPasswordCheckbox");

    if (showPasswordCheckbox.checked){
      passwordInput.type = "text";
    }
    else{
      passwordInput.type = "password";
    }
  }