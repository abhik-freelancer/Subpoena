function showHideRow(val, img) 
{
    
    if(document.getElementById(val).style.display=='none')
    {
        document.getElementById(val).style.display = '';
        document[img].src="../../../images/collapse_blue.jpg";
    }
    else
    {
        document.getElementById(val).style.display = 'none';
        document[img].src="../../../images/expand_blue.jpg";
    }
   
}
