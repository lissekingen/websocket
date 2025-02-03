using System.Net.WebSockets;
using System.Text;

class Program{
  static async Task Main(){
    Uri web = new Uri("ws://echo.websocket.org");
    ClientWebSocket urisocket = new ClientWebSocket();
    await urisocket.ConnectAsync(web,default);
    string uristring = "hugo är så smart";
    byte[]emsg=Encoding.UTF8.GetBytes(uristring);
    ArraySegment<byte>smsg=new(emsg);
    await urisocket.SendAsync(smsg,WebSocketMessageType.Text,true,CancellationToken.None);
    byte[] res=new byte[1024];
    var bres = await urisocket.ReceiveAsync (new ArraySegment<byte>(res),CancellationToken.None);
    string YEAH = Encoding.UTF8.GetString(res,0,bres.Count);
    Console.WriteLine(YEAH);
  }
}