using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;


namespace AudioSteganographyThesisProject.Algorithm
{
    public static class ExistingTechnique1
    {
        public static string messageBinary = "";
        public static char[] messageLengthBinaryChar;
        public static char[] secretMesssgaeBinary;
        public static StringBuilder secretMessageBitLeft = new StringBuilder();
        public static StringBuilder secretMessageBitRight = new StringBuilder();
        public static StringBuilder totalSecretMessageBit = new StringBuilder();

        public static string HideMessage(string message, string stego_file_name, string cover_file_name)
        {
            try
            {
                WaveAudio waveAudio = new WaveAudio(new FileStream(cover_file_name, FileMode.Open, FileAccess.Read));
                /*Cache audio channel streams locally from WaveAudio object*/
                List<short> leftStream = waveAudio.GetLeftStream();
                List<short> rightStream = waveAudio.GetRightStream();
                
                secretMesssgaeBinary = messageBinaryFormat(message);

                if (secretMesssgaeBinary.Length >= ((leftStream.Count * 2) - 162)) //Check if message stream length is greater than a channel's audio stream length. here 148 bit is metadata size 
                    throw new Exception("Message size is too large for target Audio stream."); //Throw an Exception.

                messageLengthBinaryChar = messageLengthBinaryFormat(message.Length);

                int messageLengthTrack = 0;
                for (int i = 46; i < 76; i++)
                {
                    int leftStreamValue = leftStream[i];
                    int test = leftStreamValue;
                    int evenodd = 1;
                    if (leftStreamValue < 0)
                    {
                        evenodd = -1;
                        leftStreamValue = leftStreamValue * evenodd; //if value is odd then we convert to even so that we can convert into binary easily
                    }
                    string binaryValueLeftStreamValue = Convert.ToString(leftStreamValue, 2).PadLeft(16, '0');
                    int newLeftStreamValue = Convert.ToInt32((binaryValueLeftStreamValue.Substring(0, binaryValueLeftStreamValue.Length - 1) + messageLengthBinaryChar[messageLengthTrack]), 2) * evenodd;
                    Console.WriteLine(test + "_" + newLeftStreamValue);
                    //leftStream.Insert(i, (short)newLeftStreamValue); //Replace audio data bit with message bit.
                    leftStream[i] = (short)newLeftStreamValue;
                    messageLengthTrack++;
                }

                //secret message bit always concealed into leftStream[85 - n/2] & rightStream[85 - n/2]
                int msgBinaryhalf = (int)Math.Round(secretMesssgaeBinary.Length / 2.0);
                Thread thread1 = new Thread(() =>
                {
                    int messageTrackFirstHalf = 0;
                    for (int i = 85; i < msgBinaryhalf + 85; i++)
                    {
                        int leftStreamValue = leftStream[i];
                        int evenodd = 1;
                        if (leftStreamValue < 0)
                        {
                            evenodd = -1;
                            leftStreamValue = leftStreamValue * evenodd; //if value is odd then we convert to even so that we can convert into binary easily
                        }
                        string binaryValueLeftStreamValue = Convert.ToString(leftStreamValue, 2).PadLeft(16, '0');




                        int newLeftStreamValue = 0;

                        if (binaryValueLeftStreamValue[0].ToString() == "0" && binaryValueLeftStreamValue[1].ToString() == "0")
                        {
                            //embed into 1st LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueLeftStreamValue)
                            {
                                ltr.Add(l);
                            }
                            ltr[15] = secretMesssgaeBinary[messageTrackFirstHalf];
                            newLeftStreamValue = Convert.ToInt32(new string(ltr.ToArray()), 2) * evenodd;
                        }
                        else if (binaryValueLeftStreamValue[0].ToString() == "0" && binaryValueLeftStreamValue[1].ToString() == "1")
                        {
                            //embed into 2nd LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueLeftStreamValue)
                            {
                                ltr.Add(l);
                            }
                            ltr[14] = secretMesssgaeBinary[messageTrackFirstHalf];
                            newLeftStreamValue = Convert.ToInt32(new string(ltr.ToArray()), 2) * evenodd;
                        }
                        else if (binaryValueLeftStreamValue[0].ToString() == "1" && binaryValueLeftStreamValue[1].ToString() == "0")
                        {
                            //embed into 3rd LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueLeftStreamValue)
                            {
                                ltr.Add(l);
                            }
                            ltr[13] = secretMesssgaeBinary[messageTrackFirstHalf];
                            newLeftStreamValue = Convert.ToInt32(new string(ltr.ToArray()), 2) * evenodd;
                        }
                        else if (binaryValueLeftStreamValue[0].ToString() == "1" && binaryValueLeftStreamValue[1].ToString() == "1")
                        {
                            //embed into 4th LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueLeftStreamValue)
                            {
                                ltr.Add(l);
                            }
                            ltr[12] = secretMesssgaeBinary[messageTrackFirstHalf];
                            newLeftStreamValue = Convert.ToInt32(new string(ltr.ToArray()), 2) * evenodd;
                        }

                        //newLeftStreamValue = Convert.ToInt32((binaryValueLeftStreamValue.Substring(0, binaryValueLeftStreamValue.Length - 1) + secretMesssgaeBinary[messageTrackFirstHalf]), 2) * evenodd;
                        //leftStream.Insert(i, (short)newLeftStreamValue); //Replace audio data bit with message bit.
                        leftStream[i] = (short)newLeftStreamValue;
                        messageTrackFirstHalf++;
                    }
                });
                Thread thread2 = new Thread(() =>
                {
                    int messageTrackSecondHalf = msgBinaryhalf;
                    for (int i = msgBinaryhalf + 85; i < secretMesssgaeBinary.Length + 85; i++)
                    {
                        int rightStreamValue = rightStream[i];
                        int evenodd = 1;
                        if (rightStreamValue < 0)
                        {
                            evenodd = -1;
                            rightStreamValue = rightStreamValue * evenodd; //if value is odd then we convert to even so that we can convert into binary easily
                        }
                        string binaryValueRightStreamValue = Convert.ToString(rightStreamValue, 2).PadLeft(16, '0');




                        int newRightStreamValue = 0;

                        if (binaryValueRightStreamValue[0].ToString() == "0" && binaryValueRightStreamValue[1].ToString() == "0")
                        {
                            //embed into 1st LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueRightStreamValue)
                            {
                                ltr.Add(l);
                            }
                            ltr[15] = secretMesssgaeBinary[messageTrackSecondHalf];
                            newRightStreamValue = Convert.ToInt32(new string(ltr.ToArray()), 2) * evenodd;
                        }
                        else if (binaryValueRightStreamValue[0].ToString() == "0" && binaryValueRightStreamValue[1].ToString() == "1")
                        {
                            //embed into 2nd LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueRightStreamValue)
                            {
                                ltr.Add(l);
                            }
                            ltr[14] = secretMesssgaeBinary[messageTrackSecondHalf];
                            newRightStreamValue = Convert.ToInt32(new string(ltr.ToArray()), 2) * evenodd;
                        }
                        else if (binaryValueRightStreamValue[0].ToString() == "1" && binaryValueRightStreamValue[1].ToString() == "0")
                        {
                            //embed into 3rd LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueRightStreamValue)
                            {
                                ltr.Add(l);
                            }
                            ltr[13] = secretMesssgaeBinary[messageTrackSecondHalf];
                            newRightStreamValue = Convert.ToInt32(new string(ltr.ToArray()), 2) * evenodd;
                        }
                        else if (binaryValueRightStreamValue[0].ToString() == "1" && binaryValueRightStreamValue[1].ToString() == "1")
                        {
                            //embed into 4th LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueRightStreamValue)
                            {
                                ltr.Add(l);
                            }
                            ltr[12] = secretMesssgaeBinary[messageTrackSecondHalf];
                            newRightStreamValue = Convert.ToInt32(new string(ltr.ToArray()), 2) * evenodd;
                        }
                        //int newRightStreamValue = Convert.ToInt32((binaryValueRightStreamValue.Substring(0, binaryValueRightStreamValue.Length - 1) + secretMesssgaeBinary[messageTrackSecondHalf]), 2) * evenodd;
                        //rightStream.Insert(i, (short)newRightStreamValue); //Replace audio data bit with message bit.
                        rightStream[i] = (short)newRightStreamValue;
                        messageTrackSecondHalf++;
                    }
                });

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();


                waveAudio.UpdateStreams(leftStream, rightStream);

                waveAudio.WriteFile(stego_file_name);

                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public static string ExtractSecretMessage(string stego_file_name)
        {
            try
            {
                WaveAudio waveAudio = new WaveAudio(new FileStream(stego_file_name, FileMode.Open, FileAccess.Read));
                /*Cache audio channel streams locally from WaveAudio object*/
                List<short> leftStream = waveAudio.GetLeftStream();
                List<short> rightStream = waveAudio.GetRightStream();

                //here we have to find the message length first 
                //List<char> binaryMessagelengthChars = new List<char>();
                string binaryMessagelengthChar = "";
                for (int i = 46; i < 76; i++)
                {
                    int leftStreamValue = leftStream[i];
                    Console.WriteLine(leftStreamValue);
                    int evenodd = 1;
                    if (leftStreamValue < 0)
                    {
                        evenodd = -1;
                        leftStreamValue = leftStreamValue * evenodd; //if value is odd then we convert to even so that we can convert into binary easily
                    }
                    string binaryValueLeftStreamValue = Convert.ToString(leftStreamValue, 2).PadLeft(16, '0');
                    //binaryMessagelengthChars.Add(binaryValueLeftStreamValue[15]);
                    binaryMessagelengthChar += binaryValueLeftStreamValue[15].ToString();
                }
                //here we get the secret message size from fixed position
                int messageLength = Convert.ToInt32(binaryMessagelengthChar, 2);

                //here we are able to find the actual bit number of secret message
                int actualMessageBinaryBitLength = BinaryMessgaeBitLength(messageLength);

                int msgBinaryhalf = (int)Math.Round(actualMessageBinaryBitLength / 2.0);

                //now we gonna start to extract the secret message bit from double channel.
                Thread thread1 = new Thread(() =>
                {
                    for (int i = 85; i < msgBinaryhalf + 85; i++)
                    {
                        int leftStreamValue = leftStream[i];
                        int evenodd = 1;
                        if (leftStreamValue < 0)
                        {
                            evenodd = -1;
                            leftStreamValue = leftStreamValue * evenodd; //if value is odd then we convert to even so that we can convert into binary easily
                        }
                        string binaryValueLeftStreamValue = Convert.ToString(leftStreamValue, 2).PadLeft(16, '0');





                        if (binaryValueLeftStreamValue[0].ToString() == "0" && binaryValueLeftStreamValue[1].ToString() == "0")
                        {
                            //embed into 1st LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueLeftStreamValue)
                            {
                                ltr.Add(l);
                            }
                            secretMessageBitLeft.Append(ltr[15]);
                        }
                        else if (binaryValueLeftStreamValue[0].ToString() == "0" && binaryValueLeftStreamValue[1].ToString() == "1")
                        {
                            //embed into 2nd LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueLeftStreamValue)
                            {
                                ltr.Add(l);
                            }
                            secretMessageBitLeft.Append(ltr[14]);
                        }
                        else if (binaryValueLeftStreamValue[0].ToString() == "1" && binaryValueLeftStreamValue[1].ToString() == "0")
                        {
                            //embed into 3rd LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueLeftStreamValue)
                            {
                                ltr.Add(l);
                            }
                            secretMessageBitLeft.Append(ltr[13]);
                        }
                        else if (binaryValueLeftStreamValue[0].ToString() == "1" && binaryValueLeftStreamValue[1].ToString() == "1")
                        {
                            //embed into 4th LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueLeftStreamValue)
                            {
                                ltr.Add(l);
                            }
                            secretMessageBitLeft.Append(ltr[12]);
                        }

                        //secretMessageBitLeft.Append(binaryValueLeftStreamValue[15]);
                    }
                });
                Thread thread2 = new Thread(() =>
                {
                    for (int i = msgBinaryhalf + 85; i < actualMessageBinaryBitLength + 85; i++)
                    {
                        int rightStreamValue = rightStream[i];
                        int evenodd = 1;
                        if (rightStreamValue < 0)
                        {
                            evenodd = -1;
                            rightStreamValue = rightStreamValue * evenodd; //if value is odd then we convert to even so that we can convert into binary easily
                        }
                        string binaryValueRightStreamValue = Convert.ToString(rightStreamValue, 2).PadLeft(16, '0');

                        if (binaryValueRightStreamValue[0].ToString() == "0" && binaryValueRightStreamValue[1].ToString() == "0")
                        {
                            //embed into 1st LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueRightStreamValue)
                            {
                                ltr.Add(l);
                            }
                            secretMessageBitRight.Append(ltr[15]);
                        }
                        else if (binaryValueRightStreamValue[0].ToString() == "0" && binaryValueRightStreamValue[1].ToString() == "1")
                        {
                            //embed into 2nd LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueRightStreamValue)
                            {
                                ltr.Add(l);
                            }
                            secretMessageBitRight.Append(ltr[14]);
                        }
                        else if (binaryValueRightStreamValue[0].ToString() == "1" && binaryValueRightStreamValue[1].ToString() == "0")
                        {
                            //embed into 3rd LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueRightStreamValue)
                            {
                                ltr.Add(l);
                            }

                            secretMessageBitRight.Append(ltr[13]);
                        }
                        else if (binaryValueRightStreamValue[0].ToString() == "1" && binaryValueRightStreamValue[1].ToString() == "1")
                        {
                            //embed into 4th LSB
                            List<char> ltr = new List<char>();
                            foreach (char l in binaryValueRightStreamValue)
                            {
                                ltr.Add(l);
                            }

                            secretMessageBitRight.Append(ltr[12]);
                        }
                    }
                });

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();


                string totalSecretMessageBitCoreString = (secretMessageBitLeft.ToString() + secretMessageBitRight.ToString());
                int initialFrame = 0;
                int perFrame = 8;
                for (int i = 0; i < messageLength; i++)
                {
                    initialFrame = perFrame * i;
                    string temp = totalSecretMessageBitCoreString.Substring(initialFrame, 8);

                    totalSecretMessageBit.Append((char)Convert.ToInt32(temp, 2));
                }


                return totalSecretMessageBit.ToString();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        private static int BinaryMessgaeBitLength(int messageLength)
        {
            messageLength *= 8;
            if (((messageLength) % 3) == 2)
            {
                messageLength += 1;
            }
            else if (((messageLength) % 3) == 1)
            {
                messageLength += 2;
            }

            return messageLength;
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new
                    Rfc2898DeriveBytes(EncryptionKey, new byte[]
                    { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new
                    Rfc2898DeriveBytes(EncryptionKey, new byte[]
                    { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static char[] messageBinaryFormat(string message)
        {
            /*
            * Here we are creating messages bit to binary form
            */
            //message is converted to 8bit binary
            StringBuilder sb = new StringBuilder();
            foreach (char c in message.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            messageBinary = sb.ToString();

            //to maintain error from pass length we have to add (extra 0 or 00)
            if (((messageBinary.Length) % 3) == 2)
            {
                messageBinary += "0";
            }
            else if (((messageBinary.Length) % 3) == 1)
            {
                messageBinary += "00";
            }

            return messageBinary.ToCharArray(); //all binary bit has been converted into array.
        }

        public static char[] messageLengthBinaryFormat(int number)
        {
            string binary = Convert.ToString(number, 2).PadLeft(30, '0');
            return binary.ToCharArray();
        }

        public static string CheckValidation(string coverFile, string stegoFile)
        {
            try
            {
                var cover = new WaveAudio(new FileStream(coverFile, FileMode.Open, FileAccess.Read));
                var stego = new WaveAudio(new FileStream(stegoFile, FileMode.Open, FileAccess.Read));

                List<short> coverLeftStream = cover.GetLeftStream();
                List<short> coverRightStream = cover.GetRightStream();

                List<short> stegoLeftStream = stego.GetLeftStream();
                List<short> stegoRightStream = stego.GetRightStream();

                //now have to measure Mean Squred Error only left stream 
                double mseGrayL = 0.0, mseGrayR = 0.0;
                for (int i = 0; i < coverLeftStream.Count; i++)
                {
                    int cValueL = coverLeftStream[i];
                    int sValueL = stegoLeftStream[i];

                    int cValueR = coverRightStream[i];
                    int sValueR = stegoRightStream[i];

                    double sumL = Math.Pow(cValueL - sValueL, 2);
                    double sumR = Math.Pow(cValueR - sValueR, 2);

                    mseGrayL += sumL;
                    mseGrayR += sumR;
                }

                double mse = (((mseGrayL) / ((coverLeftStream.Count))) + ((mseGrayR) / ((coverRightStream.Count)))) / 2;
                double PSNR = 10 * Math.Log10(4294836225 / mse);

                string validation = "MSE : " + mse.ToString() + Environment.NewLine + "PSNR : " + PSNR.ToString() + Environment.NewLine;

                return validation;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
