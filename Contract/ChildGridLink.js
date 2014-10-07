<script>
window.attachEvent("onload", init);

function init(){
    var classElements = [];
    allElements = document.getElementsByTagName('A');
    for (var i = 0; i < allElements.length; i++) {
    var url=allElements[i].href;
    var strAddr; 
   
    if (url.toString().toLowerCase().search('dotnetdll=Contract')!=-1) {
        if(url.toString().toLowerCase().search('dotnetfunc=RunContractDetailSummary')!=-1){
        strAddr =url.toString();
        //alert(strAddr);  
        var strURL = strAddr + '&J=ContractDetail Summary'; 

        allElements[i].href=strURL;
     }
    }
  }
}
</script>


