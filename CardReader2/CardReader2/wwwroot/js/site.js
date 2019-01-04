// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


// Getting the student information
function getValues() {

    // Gets Student ID
    var id = document.getElementById("ID").value;
    alert(id);
    window.localStorage.setItem('Student ID', id);

    // Signing in == 0 Signing Out == 1
    var signInOut = document.getElementsByName('Sign');
    var checkedSignInOut = [];

    for (var j = 0; j < signInOut.length; j++) {
        if (signInOut[j].checked) {
            checkedSignInOut.push(signInOut[j].value);
        }
    }
    alert(checkedSignInOut);
    window.localStorage.setItem('Sign(0 - in /1 - out)', checkedSignInOut);


    // What the person is at the Tutoring center for
    var use = document.getElementsByName('CenterUseChoice');
    var checkedUse = [];

    for (var i = 0; i < use.length; i++) {
        if (use[i].checked) {
            checkedUse.push(use[i].value);
        }
    }
    alert(checkedUse);
    window.localStorage.setItem('Subject', checkedUse);

    // What subject the person is using the Tutoring Center for
    var subject = document.getElementsByName('SubjectChoice');
    var checkedSubject = [];

    for (var k = 0; k < subject.length; k++) {
        if (subject[k].checked) {
            checkedSubject.push(subject[k].value);
        }
    }
    alert(checkedSubject);
    window.localStorage.setItem('Subject', checkedSubject);

    // Math teachers name if applicable
    var mathTeach = document.getElementById("MathMakeUp").value;
    alert(mathTeach);
    window.localStorage.setItem('Math Teacher Name', mathTeach);

}


// Not allowing the "Enter" button to be used when swiping
function handleEnter(field, event) {
    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if (keyCode == 13) {
        var i;
        for (i = 0; i < field.form.elements.length; i++)
            if (field == field.form.elements[i])
                break;
        i = (i + 1) % field.form.elements.length;
        field.form.elements[i].focus();
        return false;
    }
    else
        return true;
}

