var CookieName = "cms-order";
var CookieOrderStatus = "cms-order-status";
function CreateOrUpdateOrder(objOrder)
{
    var Orders = getListOrder();
    if (Orders != null && Orders.length > 0)
    {
        if (objOrder.ModifieCode == "") {
            var dataOrder = Orders.find(function (item) { return item.ItemId == objOrder.ItemId })
            if (dataOrder != null) {
                dataOrder.Quantity = parseInt(dataOrder.Quantity) + parseInt(objOrder.Quantity);
            } else {
                Orders.push(objOrder);
            }
        } else {
            var dataOrder = Orders.find(function (item) { return (item.ItemId == objOrder.ItemId && item.ModifieCode == objOrder.ModifieCode) })
            if (dataOrder != null) {
                dataOrder.Quantity = parseInt(dataOrder.Quantity) + parseInt(objOrder.Quantity);
            } else {
                Orders.push(objOrder);
            }
        }
        //$.each(Orders, function (index, item) {
        //    if (item.ItemId === objOrder.ItemId) {
        //        if (objOrder.ModifieCode != null && objOrder.ModifieCode != '') {
        //            if (item.ModifieCode != null && item.ModifieCode != '' && item.ModifieCode === objOrder.ModifieCode) {
        //                item.Quantity = parseInt(item.Quantity) + parseInt(objOrder.Quantity);
        //            } else {
        //                Orders.push(objOrder);
        //            }
        //        } else {
        //            // update quantity
        //            item.Quantity = parseInt(item.Quantity) + parseInt(objOrder.Quantity);
        //        }
        //    } else {
        //        Orders.push(objOrder);
        //    }
        //});
        
        // remove cookie current
        Cookies.remove(CookieName);
        //add new cookie
        Cookies.set(CookieName, Orders, { expires: 1 });
    }
    else {
        var _order = [];
        _order.push(objOrder);
        Cookies.set(CookieName, _order, { expires: 1 })
    }
    //get list order again
    Orders = getListOrder();
}

function getListOrder()
{
    var Orders = null;
    var _Order = Cookies.getJSON(CookieName)
    if (_Order != undefined)
    {
        Orders = _Order;
        if (Orders !== undefined && Orders !== null) {
            var _Quantity = 0;
            $.each(Orders, function (index, item) {
                _Quantity = parseInt(_Quantity) + parseInt(item.Quantity);
            });
            $('#CartCount').text(_Quantity);
        }
    }
    if (Orders != null && Orders.length > 0) {
        Cookies.set(CookieOrderStatus, "Inprocess", { expires: 1 });
    }
    return Orders;
}

function deleteOrder() {
    Cookies.remove(CookieName);
    $('#CartCount').text(0);
}

function UpdateQuantity(itemId, qty)
{
    var Orders = getListOrder();
    if (Orders != null) {
        $.each(Orders, function (index, item) {
            if (item.ItemId === itemId) {
                // update quantity
                item.Quantity = qty;
            }
        });
        // remove cookie current
        Cookies.remove(CookieName);
        //add new cookie
        Cookies.set(CookieName, Orders, { expires: 1 });
    }
}

function RemoveOrderByItemId(itemId)
{
    var Orders = getListOrder();
    if (Orders != null)
    {
        var flgRemoveCookie = false;
        for (var i = 0; i < Orders.length; i++) {
            if (Orders[i].ItemId === itemId) {
                Orders.splice(i, 1);
                flgRemoveCookie = true;
            }
        }
        if (flgRemoveCookie) {
            Cookies.remove(CookieName);
            Cookies.set(CookieName, Orders);
        } 
    }
}

function RegexEmail(Email) {
    var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
    if (!pattern.test(Email))
        return false;
    return true;
}

function GetStatusCart() {
    var status = Cookies.getJSON(CookieOrderStatus);
    return status;
}