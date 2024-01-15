﻿//using System.Web;

//namespace DepedencyInjectionPattern.ARCHIVED;

//public class ToastMessagesDriver : DriverDecorator
//{
//    public override string Url => throw new NotImplementedException();

//    public ToastMessagesDriver(IDriver driver)
//    : base(driver)
//    {
//    }

//    public override void GoToUrl(string url)
//    {
//        InjectNotificationToast($"Go to URL = {url}");
//        Driver?.GoToUrl(url);
//    }

//    public override IComponent FindComponent(By locator)
//    {
//        InjectNotificationToast($"Find Element -> by {locator}");
//        return Driver?.FindComponent(locator);
//    }

//    public override List<IComponent> FindComponents(By locator)
//    {
//        InjectNotificationToast($"Find elements -> by {locator}");
//        return Driver?.FindComponents(locator);
//    }

//    public override void Refresh()
//    {
//        InjectNotificationToast("refresh");
//        Driver?.Refresh();
//    }

//    public override bool ComponentExists(IComponent component)
//    {
//        InjectNotificationToast("check if the component exists");
//        return (bool)Driver?.ComponentExists(component);
//    }

//    public void InjectNotificationToast(string message, int timeoutMillis = 1500, ToastNotificationType type = ToastNotificationType.Information)
//    {
//        //Console.WriteLine($"|--{type}--| {message}");
//        var escapedMessage = HttpUtility.JavaScriptStringEncode(message);
//        var executionScript = @"window.$bellatrixToastContainer = !window.$bellatrixToastContainer ? Object.assign(document.createElement('div'), {id: 'bellatrixToastContainer', style: 'position: fixed; top: 0; height: 100vh; padding-bottom: 20px; display: flex; pointer-events: none; z-index: 2147483646; justify-content: flex-end; flex-direction: column; overflow: hidden;'}) : window.$bellatrixToastContainer;
//                let $message = '" + escapedMessage + @"';
//                let $timeout = " + timeoutMillis + @";
//                let $type = '" + type.ToString() + @"';
//                if (!document.querySelector('#bellatrixToastContainer')) document.body.appendChild(window.$bellatrixToastContainer);
//                let $bellatrixToast
//                switch ($type.toLowerCase()) {
//                    case 'warning':
//                        $bellatrixToast = Object.assign(document.createElement('div'), {textContent: $message.trim() ? $message : 'message not set', style: 'pointer-events: none; z-index: 2147483647; color: ' + ($message.trim() ? '#2e0f00' : '#2e0f0088') + '; width: fit-content; background-color: #fdefc9; margin: 5px 10px; border-radius: 10px; padding: 15px 10px 15px 52px; background-repeat: no-repeat; background-position: 5px center; font-family: Arial, Helvetica, sans-serif; font-size: 15px; line-height: 15px; box-shadow: 0px 0.6px 0.7px rgba(0, 0, 0, 0.1), 0px 1.3px 1.7px rgba(0, 0, 0, 0.116), 0px 2.3px 3.5px rgba(0, 0, 0, 0.128), 0px 4.2px 7.3px rgba(0, 0, 0, 0.135), 0px 10px 20px rgba(0, 0, 0, 0.13); background-image: url(\'data:image/svg+xml,<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 22 22""><circle cx=""11"" cy=""-1041.36"" r=""8"" transform=""matrix(1 0 0-1 0-1030.36)"" opacity="".98"" fill=""%23ffb816""/><path d=""m-26.309 18.07c-1.18 0-2.135.968-2.135 2.129v12.82c0 1.176.948 2.129 2.135 2.129 1.183 0 2.135-.968 2.135-2.129v-12.82c0-1.176-.946-2.129-2.135-2.129zm0 21.348c-1.18 0-2.135.954-2.135 2.135 0 1.18.954 2.135 2.135 2.135 1.181 0 2.135-.954 2.135-2.135 0-1.18-.952-2.135-2.135-2.135z"" transform=""matrix(.30056 0 0 .30056 18.902 1.728)"" fill=""%23fff"" stroke=""%23fff""/></svg>\');'});
//                        break;
//                    case 'error':
//                        $bellatrixToast = Object.assign(document.createElement('div'), {textContent: $message.trim() ? $message : 'message not set', style: 'pointer-events: none; z-index: 2147483647; color: ' + ($message.trim() ? '#2e0004' : '#2e000488') + '; width: fit-content; background-color: #fdc9d2; margin: 5px 10px; border-radius: 10px; padding: 15px 10px 15px 52px; background-repeat: no-repeat; background-position: 5px center; font-family: Arial, Helvetica, sans-serif; font-size: 15px; line-height: 15px; box-shadow: 0px 0.6px 0.7px rgba(0, 0, 0, 0.1), 0px 1.3px 1.7px rgba(0, 0, 0, 0.116), 0px 2.3px 3.5px rgba(0, 0, 0, 0.128), 0px 4.2px 7.3px rgba(0, 0, 0, 0.135), 0px 10px 20px rgba(0, 0, 0, 0.13); background-image: url(\'data:image/svg+xml,<svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" viewBox=""0 0 22 22""><defs><linearGradient gradientUnits=""userSpaceOnUse"" y2=""-2.623"" x2=""0"" y1=""986.67""><stop stop-color=""%23ffce3b""/><stop offset=""1"" stop-color=""%23ffd762""/></linearGradient><linearGradient id=""0"" gradientUnits=""userSpaceOnUse"" y1=""986.67"" x2=""0"" y2=""-2.623""><stop stop-color=""%23ffce3b""/><stop offset=""1"" stop-color=""%23fef4ab""/></linearGradient><linearGradient gradientUnits=""userSpaceOnUse"" x2=""1"" x1=""0"" xlink:href=""%230""/></defs><g transform=""matrix(2 0 0 2-11-2071.72)""><path transform=""translate(7 1037.36)"" d=""m4 0c-2.216 0-4 1.784-4 4 0 2.216 1.784 4 4 4 2.216 0 4-1.784 4-4 0-2.216-1.784-4-4-4"" fill=""%23da4453""/><path d=""m11.906 1041.46l.99-.99c.063-.062.094-.139.094-.229 0-.09-.031-.166-.094-.229l-.458-.458c-.063-.062-.139-.094-.229-.094-.09 0-.166.031-.229.094l-.99.99-.99-.99c-.063-.062-.139-.094-.229-.094-.09 0-.166.031-.229.094l-.458.458c-.063.063-.094.139-.094.229 0 .09.031.166.094.229l.99.99-.99.99c-.063.062-.094.139-.094.229 0 .09.031.166.094.229l.458.458c.063.063.139.094.229.094.09 0 .166-.031.229-.094l.99-.99.99.99c.063.063.139.094.229.094.09 0 .166-.031.229-.094l.458-.458c.063-.062.094-.139.094-.229 0-.09-.031-.166-.094-.229l-.99-.99"" fill=""%23fff""/></g></svg>\');'});
//                        break;
//                    case 'success':
//                        $bellatrixToast = Object.assign(document.createElement('div'), {textContent: $message.trim() ? $message : 'message not set', style: 'pointer-events: none; z-index: 2147483647; color: ' + ($message.trim() ? '#002e0a' : '#002e0a88') + '; width: fit-content; background-color: #c9fdd4; margin: 5px 10px; border-radius: 10px; padding: 15px 10px 15px 52px; background-repeat: no-repeat; background-position: 5px center; font-family: Arial, Helvetica, sans-serif; font-size: 15px; line-height: 15px; box-shadow: 0px 0.6px 0.7px rgba(0, 0, 0, 0.1), 0px 1.3px 1.7px rgba(0, 0, 0, 0.116), 0px 2.3px 3.5px rgba(0, 0, 0, 0.128), 0px 4.2px 7.3px rgba(0, 0, 0, 0.135), 0px 10px 20px rgba(0, 0, 0, 0.13); background-image: url(\'data:image/svg+xml,<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 22 22""><g transform=""matrix(1.99997 0 0 1.99997-10.994-2071.68)"" fill=""%23da4453""><rect y=""1037.36"" x=""7"" height=""8"" width=""8"" fill=""%2332c671"" rx=""4""/><path d=""m123.86 12.966l-11.08-11.08c-1.52-1.521-3.368-2.281-5.54-2.281-2.173 0-4.02.76-5.541 2.281l-53.45 53.53-23.953-24.04c-1.521-1.521-3.368-2.281-5.54-2.281-2.173 0-4.02.76-5.541 2.281l-11.08 11.08c-1.521 1.521-2.281 3.368-2.281 5.541 0 2.172.76 4.02 2.281 5.54l29.493 29.493 11.08 11.08c1.52 1.521 3.367 2.281 5.54 2.281 2.172 0 4.02-.761 5.54-2.281l11.08-11.08 58.986-58.986c1.52-1.521 2.281-3.368 2.281-5.541.0001-2.172-.761-4.02-2.281-5.54"" fill=""%23fff"" transform=""matrix(.0436 0 0 .0436 8.177 1039.72)"" stroke=""none"" stroke-width=""9.512""/></g></svg>\');'});
//                        break;
//                    case 'information':
//                        $bellatrixToast = Object.assign(document.createElement('div'), {textContent: $message.trim() ? $message : 'message not set', style: 'pointer-events: none; z-index: 2147483647; color: ' + ($message.trim() ? '#00122e' : '#00122e88') + '; width: fit-content; background-color: #c9ecfd; margin: 5px 10px; border-radius: 10px; padding: 15px 10px 15px 52px; background-repeat: no-repeat; background-position: 7.5px center; font-family: Arial, Helvetica, sans-serif; font-size: 15px; line-height: 15px; background-size: 40px; box-shadow: 0px 0.6px 0.7px rgba(0, 0, 0, 0.1), 0px 1.3px 1.7px rgba(0, 0, 0, 0.116), 0px 2.3px 3.5px rgba(0, 0, 0, 0.128), 0px 4.2px 7.3px rgba(0, 0, 0, 0.135), 0px 10px 20px rgba(0, 0, 0, 0.13); background-image: url(\'data:image/svg+xml,<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 64 64""><g transform=""matrix(.92857 0 0 .92857-691.94-149.37)""><circle cx=""779.63"" cy=""195.32"" r=""28"" fill=""%230c9fdd""/><g fill=""%23fff"" fill-rule=""evenodd"" fill-opacity="".855""><path d=""m779.62639 179.16433a3.589743 3.589743 0 0 1 3.58975 3.58975 3.589743 3.589743 0 0 1 -3.58975 3.58974 3.589743 3.589743 0 0 1 -3.58974 -3.58974 3.589743 3.589743 0 0 1 3.58974 -3.58975""/><path d=""m779.24 189.93h.764c1.278 0 2.314 1.028 2.314 2.307v16.925c0 1.278-1.035 2.307-2.314 2.307h-.764c-1.278 0-2.307-1.028-2.307-2.307v-16.925c0-1.278 1.028-2.307 2.307-2.307""/></g></g></svg>\');'});             
//                }
//                window.$bellatrixToastContainer.appendChild($bellatrixToast);
//                setTimeout($bellatrixToast.remove.bind($bellatrixToast), $timeout);";

//        Driver.ExecuteScript(executionScript);
//    }
//}
