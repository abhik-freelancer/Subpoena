function HideSummary()
{
document.getElementById('divSummary').style.display='table';
document.getElementById('divCommonCore').style.display='none';
document.getElementById('divCompulsory').style.display='none';
document.getElementById('divOptionCompulsory').style.display='none';
document.getElementById('divClassifiedElective').style.display='none';
document.getElementById('divSpecifiedElective').style.display='none';

}
function HideCommonCore()
{
document.getElementById('divCommonCore').style.display='table';
document.getElementById('divSummary').style.display='none';
document.getElementById('divCompulsory').style.display='none';
document.getElementById('divOptionCompulsory').style.display='none';
document.getElementById('divClassifiedElective').style.display='none';
document.getElementById('divSpecifiedElective').style.display='none';
}
function HideCompulsory()
{
document.getElementById('divCompulsory').style.display='table';
document.getElementById('divCommonCore').style.display='none';
document.getElementById('divSummary').style.display='none';
document.getElementById('divOptionCompulsory').style.display='none';
document.getElementById('divClassifiedElective').style.display='none';
document.getElementById('divSpecifiedElective').style.display='none';
}
function HideOptionCompulsory()
{
document.getElementById('divOptionCompulsory').style.display='table';
document.getElementById('divCompulsory').style.display='none';
document.getElementById('divCommonCore').style.display='none';
document.getElementById('divSummary').style.display='none';
document.getElementById('divClassifiedElective').style.display='none';
document.getElementById('divSpecifiedElective').style.display='none';
}
function HideClassifiedElective()
{
document.getElementById('divOptionCompulsory').style.display='none';
document.getElementById('divCompulsory').style.display='none';
document.getElementById('divCommonCore').style.display='none';
document.getElementById('divSummary').style.display='none';
document.getElementById('divClassifiedElective').style.display='table';
document.getElementById('divSpecifiedElective').style.display='none';
}

function HideSpecifiedElective()
{
document.getElementById('divOptionCompulsory').style.display='none';
document.getElementById('divCompulsory').style.display='none';
document.getElementById('divCommonCore').style.display='none';
document.getElementById('divSummary').style.display='none';
document.getElementById('divClassifiedElective').style.display='none';
document.getElementById('divSpecifiedElective').style.display='table';
}