function ToFloat(x) { x = parseFloat(x); return isNaN(x) ? 0 : x; }
function ToInt(x) { x = parseInt(x); return isNaN(x) ? 0 : x; }



async function createAccount(e) {
    e.preventDefault();

    let frm = document.getElementById("frmCreateAccount");
    let modelName = frm.getAttribute("dataModelName");
    let dto = { title : '', amount : 0, type : 0, params : [] };
    if (modelName == "Deposit")
    {

        dto.type = 1;
        dto.title = frm.elements[0].value;
        dto.amount = ToFloat(frm.elements[1].value);
        dto.params = [
            // bic
            frm.elements[2].value,
            // corrAccount
            frm.elements[4].value,
            // bankName
            frm.elements[3].value,
            // percent
            ToFloat(frm.elements[6].value),
            // depositType
            ToInt(frm.elements[7].value),
            // numberOfBankAccount
            frm.elements[5].value,
            ];        
    
    }
 
    
    let result = await fetch("/api/Accounts",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dto)
        });
    if (result.status == 200) {
        alert("счет создан");
    }
}

async function createOperation(e) {
    let frm = document.getElementById("frmCreateOperation");
    let dto = { comment: '', amount: 0, debetAccountId: 0, creditAccountId: 0 };
    dto.debetAccountId = ToInt(frm.elements[0].value);
    dto.creditAccountId = ToInt(frm.elements[1].value);
    dto.amount = ToFloat(frm.elements[2].value);
    dto.comment = frm.elements[3].value;


    let result = await fetch("/api/Operations",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(dto)
        });

    if (result.status == 200) {
        alert("операция создана");
    }
}

async function loadAccount(el)
{   

    let result = await fetch("/api/Accounts",
        {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        });
    
    if (result.status == 200) {
    
        let data = await result.json();
        data.forEach(function (item) {
            option = document.createElement("option");
            option.text = item.title;
            option.value = item.id;
            el.appendChild(option);
        });
    }

    
  

}

window.addEventListener("load", () => {

    var els = document.querySelectorAll('button[id*="CreateAccount"]');
    els.forEach(function (el) {
        el.addEventListener("click", createAccount);
    });

    var els = document.querySelectorAll('button[id*="CreateOperation"]');
    els.forEach(function (el) {
        el.addEventListener("click", createOperation);
    });

    var els = document.querySelectorAll('select[name*="Account"]')
    els.forEach(function (el) {
        loadAccount(el);
    });
          
   // let ok = document.getElementById("createDepositAccountButton");
   // ok.addEventListener("click", createAccount);

});


