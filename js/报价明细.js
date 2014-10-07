<script>
window.attachEvent("onload", init);
function init(){
var currency = document.getElementById("currency").value;
if(currency.length < 1)
	currency = "ÈËÃñ±Ò";
var price = document.getElementById('_Captqtdt_price');
price.innerText = price.innerText+ "("+currency+"/Ôª)";
	
	
}

function updateamount()
{
	var count = document.getElementById('qtdt_count').value;
	var price = document.getElementById('qtdt_price').value;
	var discount = document.getElementById('qtdt_discount').value;
	count = checkfield(count);
	price = checkfield(price);
	discount = checkfield(discount);
	//
	var result = ((discount/100)*price*count).toFixed(3);
	//alert(count+"--" +price +"--" + discount +"----"+result);
	var localeamount = document.getElementById('_Dataqtdt_localeamount');
	localeamount.innerText = result;
	
	var exchange = document.getElementById("exchange").value;
	//alert(exchange);
	var foreresult = (result*exchange).toFixed(3);
	var foreignamount = document.getElementById("_Dataqtdt_foreignamount");
	foreignamount.innerText=foreresult;
	document.getElementByName("_HIDDENqtdt_localeamount")[0].value=result ;
	document.getElementByName("_HIDDENqtdt_foreignamount")[0].value=foreresult ;
	//alert('1');
}
function checkfield(str)
{
	if(str != '' && str != null && str+'' != 'undefined')
	{
		return str;
	}
	else return 0;
}
</script>