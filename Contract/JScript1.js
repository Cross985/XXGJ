<script>
window.attachEvent("onload", init);

function init(){
	var cont_title=document.getElementById('cont_title');
	var cont_postcode=document.getElementById('cont_postcode');
	var cont_mail=document.getElementById('cont_mail');
	var cont_fax=document.getElementById('cont_fax');
	var cont_address=document.getElementById('cont_address');
	var cont_telephone=document.getElementById('cont_telephone');
	
	cont_title.readOnly = true;     
  cont_title.style.border ='none';
  cont_postcode.readOnly = true;     
  cont_postcode.style.border ='none';
  cont_mail.readOnly = true;     
  cont_mail.style.border ='none';
  cont_fax.readOnly = true;     
  cont_fax.style.border ='none';
  cont_address.readOnly = true;     
  cont_address.style.border ='none';
  cont_telephone.readOnly = true;     
  cont_telephone.style.border ='none'; 
}
function updateDetail(){
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
	id = document.getElementById('cont_personid').value;
	if(id=='undefined'||id==''){
	document.getElementById('cont_title').value ="";
	document.getElementById('cont_postcode').value ="";
	document.getElementById('cont_mail').value ="";
	document.getElementById('cont_fax').value ="";
	document.getElementById('cont_address').value ="";
	document.getElementById('cont_telephone').value ="";
	}
	if(id!=null&&id!='undefined'&&id!=''){
		var strURL ='';
		strURL = strAddr + 'CustomPages/Contract/GetDetail.asp?cont_personid=' + id +'&' + strQS;	
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
   if(strHtml.split('#')[0]!=''&& strHtml.split('#')[0]!='undefined'){
	 // always clear the XmlHttp object when you are done to avoid memory leaks		
   // if(strHtml.split('#')[0]!=''&& strHtml.split('#')[0]!='undefined'){
     cont_title=document.getElementById('cont_title');    
     cont_title.value=strHtml.split('#')[0];
    }else{       
    cont_title=document.getElementById('cont_title');    
    cont_title.value="";
    }
    if(strHtml.split('#')[1]!=''&& strHtml.split('#')[1]!='undefined'){
     cont_postcode=document.getElementById('cont_postcode');    
     cont_postcode.value=strHtml.split('#')[1];
    }else{       
    cont_postcode=document.getElementById('cont_postcode');    
    cont_postcode.value="";
    }
    if(strHtml.split('#')[2]!=''&& strHtml.split('#')[2]!='undefined'){
     cont_mail=document.getElementById('cont_mail');    
     cont_mail.value=strHtml.split('#')[2];
    }else{       
    cont_mail=document.getElementById('cont_mail');    
    cont_mail.value="";
    }
  if(strHtml.split('#')[3]!=''&& strHtml.split('#')[3]!='undefined'){
     cont_fax=document.getElementById('cont_fax');    
     cont_fax.value=strHtml.split('#')[3];
    }else{       
    cont_fax=document.getElementById('cont_fax');    
    cont_fax.value="";
    }
    //alert(strHtml.split('#')[4]);
	if(strHtml.split('#')[4]!=''&& strHtml.split('#')[4]!='undefined'){
     cont_address=document.getElementById('cont_address');    
     cont_address.value=strHtml.split('#')[4];
    }else{       
    cont_address=document.getElementById('cont_address');    
    cont_address.value="";
    }
    //alert(strHtml.split('#')[5]);
	if(strHtml.split('#')[5]!=''&& strHtml.split('#')[5]!='undefined'){
     cont_telephone=document.getElementById('cont_telephone');    
     cont_telephone.value=strHtml.split('#')[5];
    }else{       
    cont_telephone=document.getElementById('cont_telephone');    
    cont_telephone.value="";
    }
   }
}
</script>