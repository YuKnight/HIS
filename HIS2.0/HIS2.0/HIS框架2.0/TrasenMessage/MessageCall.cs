using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
namespace TrasenMessage
{
    [Serializable]
    public class MessageCall : IMessageProcessor
    {
        private string _parameter;
        private string sender;
        private const int portNum = 4667;
        //private bool listen;///侦听标志
        //private TcpListener listener;
        //private string path;  //声音文件路径
        private static Mutex muxConsole = new Mutex( );
        
        /// <summary>
        /// 消息颜色
        /// </summary>
        public System.Drawing.Color Color
        {
            get
            {
                return System.Drawing.Color.Black;
            }
            set
            {
                 
            }
        }
        public Guid MessageId
        {
            get
            {
                return Guid.Empty;
            }
            set
            {
            }
        }
        

        public MessageCall( string parameter )
		{

			this._parameter = parameter;

		}

		[DllImport("winmm.dll", SetLastError=true, CallingConvention=CallingConvention.Winapi)]
		static extern bool PlaySound( string pszSound,IntPtr hMod, SoundFlags sf );

		[Flags]
		public enum SoundFlags : int 
		{
			SND_SYNC = 0x0000,  /* play synchronously (default) */
			SND_ASYNC = 0x0001,  /* play asynchronously */
			SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
			SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
			SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
			SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
			SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
			SND_ALIAS = 0x00010000, /* name is a registry alias */
			SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
			SND_FILENAME = 0x00020000, /* name is file name */
			SND_RESOURCE = 0x00040004  /* name is resource name or atom */
		}
		
		//播放声音
		private void play(string no,string room)
		{
			string path= AppDomain.CurrentDomain.SetupInformation.ApplicationBase+"\\Voice\\"; 
			PlaySound(path+"请.wav", IntPtr.Zero,SoundFlags.SND_SYNC);
            if ( no != null )
            {
                for ( int i = 0 ; i < no.Length ; i++ )
                {
                    PlaySound( path + no[i].ToString( ) + ".wav" , IntPtr.Zero , SoundFlags.SND_SYNC );
                }
            }
			PlaySound(path+"号.wav", IntPtr.Zero,SoundFlags.SND_SYNC);			
			PlaySound(path+"到.wav", IntPtr.Zero,SoundFlags.SND_SYNC);
            if ( room != null )
            {
                for ( int i = 0 ; i < room.Length ; i++ )
                {
                    PlaySound( path + room[i].ToString( ) + ".wav" , IntPtr.Zero , SoundFlags.SND_SYNC );
                }
            }
			PlaySound(path+"诊.wav", IntPtr.Zero,SoundFlags.SND_SYNC); 
			PlaySound(path+"室.wav", IntPtr.Zero,SoundFlags.SND_SYNC); 
		}
		//叫号
		public void Caller()
		{
			if(this._parameter!=null)
			{
				string cmd=this._parameter;
				int i=0;
				string ID,ROOM;			
				ID=null;
				ROOM=null;
		        muxConsole.WaitOne();//互斥标志
				while (i<cmd.Length)
				{
					
					if (cmd[i].ToString()=="I")
					{
						i++;
						while((cmd[i].ToString()!="R")&&(i<cmd.Length))
						{
							ID=ID+cmd[i].ToString();
							i++;
						
						}	
					
					}
					if (cmd[i].ToString()=="R")
					{
						i++;
						while((cmd[i].ToString()!="M")&&(i<cmd.Length))
						{
							ROOM=ROOM+cmd[i].ToString();
							i++;
						
						}	
					
					}
					i++;
				}
				play(ID.Trim(),ROOM.Trim());
				muxConsole.ReleaseMutex();		


			}

		}

        #region IMessageProcessor 成员
        void IMessageProcessor.Process()
        {
            Caller( );
        }
        

        public string MessageString
        {
            get
            {
                return _parameter;
            }
            set
            {
                _parameter = value;
            }
        }


        public string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }

        #endregion
    }
}
