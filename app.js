//Load animation if fields containing data on page load
$( document ).ready(function() {
    $(".input-login").each(function() { 
      if ($(this).val() != "") {
        $(this).parent().addClass("animation");
      }
    });
  });
  
  //Add animation when input is focused
  $(".login-input").focus(function(){
    $(this).parent().addClass("animation animation-color");
  });
  
  //Remove animation(s) when input is no longer focused
  $(".login-input").focusout(function(){
    if($(this).val() === "")
      $(this).parent().removeClass("animation");
    $(this).parent().removeClass("animation-color");
  })