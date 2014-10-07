<script>
window.attachEvent("onload", init);

function init(){
    var classElements = [];
    allElements = document.getElementsByTagName('A');
    for (var i = 0; i < allElements.length; i++) {
    var url=allElements[i].href;
    var strAddr; 
   
    if (url.toString().toLowerCase().search('dotnetdll=MarketInfo')!=-1) {
        if(url.toString().toLowerCase().search('dotnetfunc=RunBrandRateSummary')!=-1){
        strAddr =url.toString();
        //alert(strAddr);  
        var strURL = strAddr + '&J=BrandRate Summary'; 

        allElements[i].href=strURL;
     }
    }
  }
}
</script>


