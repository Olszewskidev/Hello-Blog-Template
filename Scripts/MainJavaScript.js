//On click go to Fresh3posts
$("#buttonToFresh3, #buttonToContact").click(function () {
    var scrollTo;
    if (this.id == "buttonToFresh3")
        scrollTo = "#fresh3";
    else
        scrollTo = "#contactform";

    $('html,body').animate({
        scrollTop: $(scrollTo).offset().top
    },
        'slow');
});

//Send JSONMail
$(document).ready(function () {
    $("#SendJSONButton").on('click', function () {
        var counter = 0;
        var Name = $("#name");
        var Email = $("#exampleInputEmail");
        var Sub = $("#subject");
        var Text = $("#description");

        if (Name.val() == '')
            Name.css('border', '1px solid red');
        else
        {
            Name.css('border', 'none');
            counter++;
        }
        if (Email.val() != '' && validateEmail(Email.val())== true)
        {
            Email.css('border', 'none');
            counter++;
        }     
        else
            Email.css('border', '1px solid red');

        if (Sub.val() == '')
            Sub.css('border', '1px solid red');
        else
        {
            Sub.css('border', 'none');
            counter++;
        }
        if (Text.val() == '')
            Text.css('border', '1px solid red');
        else
        {
            Text.css('border', 'none');
            counter++;
        }
            

        if (typeof (Page_ClientValidate) == 'function') {
            Page_ClientValidate();
        }
        if (counter==4){
            $.ajax({
                type: 'POST',
                url: '/Home/Contact',
                data: "{ SenderName:'" + Name.val() + "',SenderMail:'" + Email.val() + "',SenderSubject:'" + Sub.val() + "',SenderText:'" + Text.val() + "' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    Name.val("");
                    Email.val("");
                    Text.val("");
                    Sub.val("");
                    alert(JSON.stringify(data));
                },
                error: function (data) {
                    alert(JSON.stringify(data));
                }
            });
        }
    });
});
function validateEmail(email) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
}

