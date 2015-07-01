
function doHighlight(bodyText, searchTerm, highlightStartTag, highlightEndTag)
{
if ((!highlightStartTag) || (!highlightEndTag)) {
highlightStartTag = "<font style='color:blue; background-color:yellow;'>";
highlightEndTag = "</font>";
}

var newText = "";
var i = -1;
var lcSearchTerm = searchTerm.toLowerCase();
var lcBodyText = bodyText.toLowerCase();

while (bodyText.length > 0) {
i = lcBodyText.indexOf(lcSearchTerm, i+1);
if (i < 0) {
newText += bodyText;
bodyText = "";
} else {
if (bodyText.lastIndexOf(">", i) >= bodyText.lastIndexOf("<", i)) {
if (lcBodyText.lastIndexOf("/script>", i) >= lcBodyText.lastIndexOf("<script", i)) {
newText += bodyText.substring(0, i) + highlightStartTag + bodyText.substr(i, searchTerm.length) + highlightEndTag;
bodyText = bodyText.substr(i + searchTerm.length);
lcBodyText = bodyText.toLowerCase();
i = -1;
}
}
}
}

return newText;
}

function highlightSearchTerms(controlId, searchText, treatAsPhrase, highlightStartTag, highlightEndTag)
{
if (treatAsPhrase) {
searchArray = [searchText];
} else {
searchArray = searchText.split(" ");
}

var theGrid = document.getElementById(controlId);

if (!theGrid || typeof(theGrid.innerHTML) == "undefined")
{ return false; }

var bodyText = theGrid.innerHTML;
for (var i = 0; i < searchArray.length; i++) {
bodyText = doHighlight(bodyText, searchArray[i], highlightStartTag, highlightEndTag);
}

try
{
theGrid.innerHTML = bodyText;
}
catch(err)
{}

return true;
}

