using System;
using System.Net.Sockets;
using System.Text;

public class Client
{
    private TcpClient client;
    private NetworkStream stream;
    private bool isRunning = true;

    public void StartClient(string serverIp, int port)
    {
        try
        {
            client = new TcpClient(serverIp, port);
            stream = client.GetStream();
            Console.WriteLine("Connected to server");

            // Nhận tin nhắn từ server
            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessages));
            receiveThread.Start();

            // Gửi tin nhắn tới server
            while (isRunning)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: " + e);
        }
        finally
        {
            stream.Close();
            client.Close();
        }
    }

    private void ReceiveMessages()
    {
        try
        {
            while (isRunning)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Server: {dataReceived}");
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: " + e);
        }
        finally
        {
            stream.Close();
            client.Close();
        }
    }

    public void StopClient()
    {
        isRunning = false;
    }
}
