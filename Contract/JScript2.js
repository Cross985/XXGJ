<script>
window.attachEvent("onload", init);

function init(){
    var code_money = document.getElementById("code_money");
    if(code_money!=null){
       code_money.readOnly = true;
       code_money.style.border ='none';
       } 
     }
function updateMoney(){
    var code_price = document.getElementById("code_price").value;
         if(code_price==''|| code_price=='undefined')  {
        code_price=0;
     }
     var code_day = document.getElementById("code_day").value;
         if(code_day==''|| code_day=='undefined')  {
        code_day=0;
     }
      var code_time = document.getElementById("code_time").value;
         if(code_time==''|| code_time=='undefined')  {
        code_time=0;
     }
      
    var code_money=document.getElementById ("code_money");
    sum= Number(code_price)* Number(code_day)*Number(code_time);
    code_money.value=sum;
}
function updateDate(){
	var strQS = location.href.split(/\?/)[1]; 
    var strAddr;
    if (window.location.toString().toLowerCase().search('eware.dll')==-1) 
   {
	 strAddr = window.location.toString().split('CustomPages')[0];
   } 
   else 
   {
	 strAddr = window.location.toString().split('eware.dll')[0];
   }
   
	var code_day = document.getElementById("code_day").value;
         if(code_day==''|| code_day=='undefined')  {
        code_day=0;
     }
  var code_startdate = document.getElementById("code_startdate").value;
         if(code_startdate==''|| code_startdate=='undefined')  {
        code_startdate=null;
     }  	  
if(code_startdate=='undefined'||code_startdate==''||code_day=='undefined'||code_day==''){
	document.getElementById('code_enddate').value =""; 
	}
	if(code_startdate!=null&&code_startdate!='undefined'&&code_startdate!=''&&code_day!=null&&code_day!='undefined'&&code_day!='')
	{
		
		var strURL ='';
		strURL = strAddr + 'CustomPages/ContractDetail/GetDate.asp?code_startdate=' + code_startdate +'&' + 'code_day=' + code_day +'&'+ strQS;	
		//alert(strURL);
		if (window.XMLHttpRequest){ 
			XmlHttp = new XMLHttpRequest();
		}
		else
		{
			// IE6 and before
			XmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
		}
		XmlHttp.open('GET',strURL,false); 
		XmlHttp.setRequestHeader('Content-Type', 'text/xml');
		XmlHttp.send(null); 
		var strHtml = XmlHttp.responseText;
		XmlHttp=null;  
//		alert(strHtml.split('#')[0]);
   if(strHtml.split('#')[0]!=''&& strHtml.split('#')[0]!='undefined'){
	 // always clear the XmlHttp object when you are done to avoid memory leaks		
   // if(strHtml.split('#')[0]!=''&& strHtml.split('#')[0]!='undefined'){
     code_enddate=document.getElementById('code_enddate');    
     code_enddate.value=strHtml.split('#')[0];
    }else{       
    code_enddate=document.getElementById('code_enddate');    
    code_enddate.value="";
    }
  }
}

function updateName(){
	var strQS = location.href.split(/\?/)[1]; 
    var strAddr;
    if (window.location.toString().toLowerCase().search('eware.dll')==-1) 
   {
	 strAddr = window.location.toString().split('CustomPages')[0];
   } 
   else 
   {
	 strAddr = window.location.toString().split('eware.dll')[0];
   }
   
	var code_lecturer = document.getElementById("code_lecturer").value;
         if(code_lecturer==''|| code_lecturer=='undefined')  {
        code_lecturername="";
     }
if(code_lecturer=='undefined'||code_lecturer==''){
	document.getElementById('code_lecturername').value =""; 
	}
	if(code_lecturer!=null&&code_lecturer!='undefined'&&code_lecturer!='')
	{		
		var strURL ='';
		strURL = strAddr + 'CustomPages/ContractDetail/GetName.asp?code_lecturer=' +code_lecturer +'&'+strQS;	
		//alert(strURL);
		if (window.XMLHttpRequest){ 
			XmlHttp = new XMLHttpRequest();
		}
		else
		{
			// IE6 and before
			XmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
		}
		XmlHttp.open('GET',strURL,false); 
		XmlHttp.setRequestHeader('Content-Type', 'text/xml');
		XmlHttp.send(null); 
		var strHtml = XmlHttp.responseText;
		XmlHttp=null;  
//		alert(strHtml.split('#')[0]);
   if(strHtml.split('#')[0]!=''&& strHtml.split('#')[0]!='undefined'){
	 // always clear the XmlHttp object when you are done to avoid memory leaks		
   // if(strHtml.split('#')[0]!=''&& strHtml.split('#')[0]!='undefined'){
     code_lecturername=document.getElementById('code_lecturername');    
     code_lecturername.value=strHtml.split('#')[0];
    }else{       
    code_lecturername=document.getElementById('code_lecturername');    
    code_lecturername.value="";
    }
  }
}
</script>