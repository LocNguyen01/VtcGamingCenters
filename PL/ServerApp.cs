using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Server
{
    private TcpListener listener;
    private TcpClient client;
    private NetworkStream stream;
    private bool isRunning = true;

    public void StartServer(string ipAddress, int port)
    {
        listener = new TcpListener(IPAddress.Parse(ipAddress), port);
        listener.Start();
        Console.WriteLine($"Server is running on {ipAddress}:{port}");

        // Chờ client kết nối và xử lý mỗi client trong một luồng riêng biệt
        Thread clientThread = new Thread(new ThreadStart(ListenForClients));
        clientThread.Start();
    }

    private void ListenForClients()
    {
        try
        {
            while (isRunning)
            {
                client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");

                // Xử lý mỗi client trong một luồng riêng biệt
                Thread clientHandlerThread = new Thread(new ParameterizedThreadStart(HandleClient));
                clientHandlerThread.Start(client);
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: " + e);
        }
        finally
        {
            listener.Stop();
        }
    }

    private void HandleClient(object obj)
    {
        TcpClient tcpClient = (TcpClient)obj;
        stream = tcpClient.GetStream();

        try
        {
            while (isRunning)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Client: {dataReceived}");

                // Gửi phản hồi cho client
                string response = $"Server received: {dataReceived}";
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: " + e);
        }
        finally
        {
            stream.Close();
            tcpClient.Close();
        }
    }

    public void StopServer()
    {
        isRunning = false;
    }
}
    