using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mail;
using System.Net;

namespace Novatic.Util
{
    public class EmailUtil
    {
        //public static string EMAIL_CREDENTIAL_NAME = "autoreply.gappingworld@gmail.com";
        //public static string EMAIL_CREDENTIAL_PASSWORD = "remake2019";
        //public static string EMAIL_CREDENTIAL_NAME = "novaticjsc1@gmail.com";
        //public static string EMAIL_CREDENTIAL_PASSWORD = "Abc@123456";

        public static string EMAIL_CREDENTIAL_NAME = "no.reply.a2f@gmail.com";
        public static string EMAIL_CREDENTIAL_PASSWORD = "Abc123456@@";



        //Tạm thời gửi Gmail
        public static NovaticResponse SendEmail(string recipients, string subject, string body)
        {
            var novaticResponse = SendEmailGmail(recipients, subject, body);
            //var novaticResponse = SendEmailGmail(recipients, subject, body);
            return novaticResponse;
        }

        //Harry 100721
        //Send general emails to multiple recipients using GMail
        public static NovaticResponse SendEmailGmail(string recipients, string subject, string body)
        {
            var novaticResponse = NovaticResponse.SUCCESS();
            try
            {
                var toAddresses = recipients.Split(',');
                foreach (var to in toAddresses)
                {
                    int tryAgain = 20;
                    bool failed = false;
                    do
                    {
                        Thread.Sleep(3000);
                        new Thread(() =>
                        {

                        // send  email 
                        var client = new SmtpClient("smtp.gmail.com", 587)
                            {
                                Credentials = new NetworkCredential(EmailUtil.EMAIL_CREDENTIAL_NAME, EmailUtil.EMAIL_CREDENTIAL_PASSWORD),
                                EnableSsl = true
                            };
                            client.Timeout = 1000000000;                //Timeout = 1000000000
                        MailMessage msg = new MailMessage(EmailUtil.EMAIL_CREDENTIAL_NAME, to, subject, body);
                            msg.IsBodyHtml = true;
                            try
                            {
                                client.Send(msg);
                            }
                            catch (Exception ex)
                            {
                            //throw;
                            failed = true;
                                tryAgain--;
                                var exception = ex.Message.ToString();
                            }
                        }).Start();
                    } while (failed && tryAgain != 0);
                }
            }
            catch (Exception e)
            {
                novaticResponse = NovaticResponse.BAD_REQUEST();
            }
            return novaticResponse;
        }

        public static string RegisterEventSuccess(string username, string name, string email, string phone, string businessName, string businessNumber, string eventTime, string eventName, string eventAddress)
        {
            string content = @"
            <!DOCTYPE html>
<html>
<head>

  <meta charset='utf-8'>
  <meta http-equiv='x-ua-compatible' content='ie=edge'>
  <title>Register Event Success</title>
  <meta name='viewport' content='width=device-width, initial-scale=1'>
  <link href='https://fonts.googleapis.com/css?family=Montserrat&display=swap' rel='stylesheet'>


  <style type='text/css'>
  /**
   * Google webfonts. Recommended to include the .woff version for cross-client compatibility.
   */
  

  /**
   * Avoid browser level font resizing.
   * 1. Windows Mobile
   * 2. iOS / OSX
   */
  body,
  table,
  td,
  a {
    -ms-text-size-adjust: 100%; /* 1 */
    -webkit-text-size-adjust: 100%; /* 2 */
  }

  /**
   * Remove extra space added to tables and cells in Outlook.
   */
  table,
  td {
    mso-table-rspace: 0pt;
    mso-table-lspace: 0pt;
  }

  /**
   * Better fluid images in Internet Explorer.
   */
  img {
    -ms-interpolation-mode: bicubic;
  }

  /**
   * Remove blue links for iOS devices.
   */
  a[x-apple-data-detectors] {
    font-family: inherit !important;
    font-size: inherit !important;
    font-weight: inherit !important;
    line-height: inherit !important;
    color: inherit !important;
    text-decoration: none !important;
  }

  /**
   * Fix centering issues in Android 4.4.
   */
  div[style*='margin: 16px 0;'] {
    margin: 0 !important;
  }

  body {
    width: 100% !important;
    height: 100% !important;
    padding: 0 !important;
    margin: 0 !important;
  }

  /**
   * Collapse table borders to avoid space between cells.
   */
  table {
    border-collapse: collapse !important;
  }

  a {
    color: #1a82e2;
  }

  img {
    height: auto;
    line-height: 100%;
    text-decoration: none;
    border: 0;
    outline: none;
  }
  .passwordValue{
    display: none;
  }

  .showEmailButton:active{
    background: green !important;
  }
  .showEmailButton:active .passwordValue{
    display: block !important;
  }
  .showEmailButton:active .passwordDummy{
    display: none !important;
  }
  </style> 
</head>
<body style='background-color: #e9ecef;'>

  <!-- start preheader -->
  <div class='preheader' style='display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;'>
    
  </div>
  <!-- end preheader -->

  <!-- start body -->
  <table border='0' cellpadding='0' cellspacing='0' width='100%'>

    <!-- start logo -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='90%' style='margin: 0 5%'>
          <tr>
            <td align='center' valign='top' style='padding: 36px 24px;'>
              <a href='https://a2f.business.gov.vn' target='_blank' style='display: inline-block;'>
                <img src='https://a2f.business.gov.vn/images/a2flogo.png' alt='Logo' border='0'   style='display: block; min-width: 48px;'>
              </a>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end logo -->

    <!-- start hero -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'  >
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 36px 24px 0; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; border-top: 3px solid #d4dadf;'>
              <h1 style='margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;'>Đăng ký tham gia sự kiện thành công</h1>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end hero -->

    <!-- start copy block -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;' class='showEmailButton'>

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>Thân chào " + username + @", cảm ơn bạn đã đăng ký tham gia sự kiện: <b>" + eventName + @"</b></p>
                    <h4>Cảm ơn bạn đã đăng ký tham dự sự kiện của chúng tôi. Dưới đây là thông tin đăng ký của bạn:</h4>
                    <ul>
                        <li>Họ tên: <b> " + name + @" </b>.</li>
                        <li>Email: <b> " + email + @" </b>.</li>
                        <li>Số điện thoại: <b> " + phone + @" </b>.</li>
                        <li>Tên doanh nghiệp: <b> " + businessName + @" </b>.</li>
                        <li>Số đăng ký kinh doanh: <b> " + businessNumber + @" </b>.</li>
                    </ul>

                    <h4>Dưới đây là thông tin sự kiện:</h4>

                    <p>Thời gian: " + eventTime + @"</p>
                    <p>Nội dung: " + eventName + @".</p>
                    <p>Địa điểm sự kiện: " + eventAddress + @"</a></p>
                    <p>Hẹn gặp bạn tại sự kiện!</p>
   
               </td>
   
             </tr>
   
             <!--end copy-->
   

             <!--start copy-->
   
             <tr>
   
               <td align = 'left' bgcolor = '#ffffff' style = 'padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf'>
        
                      <p style = 'margin: 0;'> Trân trọng! <br> A2F <br> Bộ kế hoạch và đầu tư - Cục phát triển doanh nghiệp</p>
                  
                              </td>
                  
                            </tr>
                  
                            <!--end copy-->
                  

                          </table>
                  
                          <!--[if (gte mso 9)| (IE)]>
                    
                            </td>
                    
                            </tr>
                    
                            </table>
                    
                            <![endif]-- >
                    
                          </td>
                    
                        </tr>
                    
                        <!--end copy block-->
                    

                        <!--start footer-->
                    
                        <tr>
                    
                          <td align = 'center' bgcolor = '#e9ecef' style = 'padding: 24px;'>
                         
                                 <!--[if (gte mso 9)| (IE)]>
                           
                                   <table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' width = '600'>
                                    
                                            <tr>
                                    
                                            <td align = 'center' valign = 'top' width = '600'>
                                         
                                                 <![endif]-->
                                         
                                                 <table border = '0' cellpadding = '0' cellspacing = '0' width = '100%' style = 'max-width: 600px;'>
                                                  

                                                            <!--start permission-->
                                                  
                                                            <tr>
                                                  
                                                              <td align = 'center' bgcolor = '#e9ecef' style = 'padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
                                                       
                                                                     <p style = 'margin: 0;' > Bạn nhận được email này vì chúng tôi đã nhận được yêu cầu từ tài khoản của bạn.</p>
                                                            
                                                                        </td>
                                                            
                                                                      </tr>
                                                            
                                                                      <!--end permission-->
                                                            

                                                                      <!--start unsubscribe-->
                                                            
                                                                      <tr>
                                                            
                                                                        <td align = 'center' bgcolor = '#e9ecef' style = 'padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
                                                                 
                                                                               <p style = 'margin: 0;' > Copyright 2022 <a href = '' target = '_blank' > A2F </a></p>
                                                                             
                                                                                           <p style = 'margin: 0;' > All rights reserved.</p>
                                                                                  
                                                                                              </td>
                                                                                  
                                                                                            </tr>
                                                                                  
                                                                                            <!--end unsubscribe-->
                                                                                  

                                                                                          </table >
                                                                                  
                                                                                          <!--[if (gte mso 9)| (IE)]>
                                                                                    
                                                                                            </td>
                                                                                    
                                                                                            </tr>
                                                                                    
                                                                                            </table>
                                                                                    
                                                                                            <![endif]-->
                                                                                    
                                                                                          </td>
                                                                                    
                                                                                        </tr>
                                                                                    
                                                                                        <!--end footer-->
                                                                                    

                                                                                      </table>
                                                                                    
                                                                                      <!--endbody-->
                                                                                    

                                                                                    </body>
                                                                                    </html>



                                                                                                                                                                   ";
            return content;
        }

        public static string RegisterSendEmail(string username, string emailAndUsername)
        {
            string content = @"
             <!DOCTYPE html>
<html>
<head>

  <meta charset='utf-8'>
  <meta http-equiv='x-ua-compatible' content='ie=edge'>
  <title>Password Reset</title>
  <meta name='viewport' content='width=device-width, initial-scale=1'>
  <link href='https://fonts.googleapis.com/css?family=Montserrat&display=swap' rel='stylesheet'>


  <style type='text/css'>
  /**
   * Google webfonts. Recommended to include the .woff version for cross-client compatibility.
   */
  

  /**
   * Avoid browser level font resizing.
   * 1. Windows Mobile
   * 2. iOS / OSX
   */
  body,
  table,
  td,
  a {
    -ms-text-size-adjust: 100%; /* 1 */
    -webkit-text-size-adjust: 100%; /* 2 */
  }

  /**
   * Remove extra space added to tables and cells in Outlook.
   */
  table,
  td {
    mso-table-rspace: 0pt;
    mso-table-lspace: 0pt;
  }

  /**
   * Better fluid images in Internet Explorer.
   */
  img {
    -ms-interpolation-mode: bicubic;
  }

  /**
   * Remove blue links for iOS devices.
   */
  a[x-apple-data-detectors] {
    font-family: inherit !important;
    font-size: inherit !important;
    font-weight: inherit !important;
    line-height: inherit !important;
    color: inherit !important;
    text-decoration: none !important;
  }

  /**
   * Fix centering issues in Android 4.4.
   */
  div[style*='margin: 16px 0;'] {
    margin: 0 !important;
  }

  body {
    width: 100% !important;
    height: 100% !important;
    padding: 0 !important;
    margin: 0 !important;
  }

  /**
   * Collapse table borders to avoid space between cells.
   */
  table {
    border-collapse: collapse !important;
  }

  a {
    color: #1a82e2;
  }

  img {
    height: auto;
    line-height: 100%;
    text-decoration: none;
    border: 0;
    outline: none;
  }
  .passwordValue{
    display: none;
  }

  .showEmailButton:active{
    background: green !important;
  }
  .showEmailButton:active .passwordValue{
    display: block !important;
  }
  .showEmailButton:active .passwordDummy{
    display: none !important;
  }
  </style> 
</head>
<body style='background-color: #e9ecef;'>

  <!-- start preheader -->
  <div class='preheader' style='display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;'>
    
  </div>
  <!-- end preheader -->

  <!-- start body -->
  <table border='0' cellpadding='0' cellspacing='0' width='100%'>

    <!-- start logo -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='90%' style='margin: 0 5%'>
          <tr>
            <td align='center' valign='top' style='padding: 36px 24px;'>
              <a href='https://a2f.business.gov.vn' target='_blank' style='display: inline-block;'>
                <img src='https://a2f.business.gov.vn/images/a2flogo.png' alt='Logo' border='0'   style='display: block; min-width: 48px;'>
              </a>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end logo -->

    <!-- start hero -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'  >
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 36px 24px 0; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; border-top: 3px solid #d4dadf;'>
              <h1 style='margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;'>Đăng ký tài khoản thành công</h1>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end hero -->

    <!-- start copy block -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;' class='showEmailButton'>

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>Thân chào " + username + @", cảm ơn bạn đã đăng ký tài khoản tại A2F!</p>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>A2F là Kênh thông tin chính thức từ Cục Phát triển Doanh nghiệp hỗ trợ Doanh nghiệp Nhỏ và Vừa của Việt Nam nâng cao khả năng tiếp cận các nguồn tài chính.</p>
                    <h4>Để kích hoạt tài khoản bạn vui lòng nhấn vào nút bên dưới: </h4>
            </td>
          </tr>
          <!-- end copy -->

          <!-- start button -->
          <tr>
            <td align='left' bgcolor='#ffffff'>
              <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                <tr>
                  <td align='center' bgcolor='#ffffff' style='padding: 12px;'>
                    <table border='0' cellpadding='0' cellspacing='0'>
                      <tr>
                        <td align='center' bgcolor='#1a82e2' style='border-radius: 6px;'>
                          <a href='" + emailAndUsername + @"' target='_blank' style='display: inline-block; padding: 16px 36px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;'>Kích hoạt tài khoản A2F</a>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr> 
          <!-- end button -->

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf'>
              <p style='margin: 0;'>Trân trọng!<br> A2F</p>
            </td>
          </tr>
          <!-- end copy -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end copy block -->

    <!-- start footer -->
    <tr>
      <td align='center' bgcolor='#e9ecef' style='padding: 24px;'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>

          <!-- start permission -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Bạn nhận được email này vì chúng tôi đã nhận được yêu cầu từ tài khoản của bạn.</p>
            </td>
          </tr>
          <!-- end permission -->

          <!-- start unsubscribe -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Copyright 2022 <a href='https://a2f.business.gov.vn' target='_blank'>A2F</a></p>
              <p style='margin: 0;'>All rights reserved.</p>
            </td>
          </tr>
          <!-- end unsubscribe -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end footer -->

  </table>
  <!-- end body -->

</body>
</html>

                                                                               ";
            return content;
        }



        public static string ForgotPassword(string username, string password, string fullname)
        {
            string content = @"<!DOCTYPE html>
<html>
<head>

  <meta charset='utf-8'>
  <meta http-equiv='x-ua-compatible' content='ie=edge'>
  <title>Password Reset</title>
  <meta name='viewport' content='width=device-width, initial-scale=1'>
  <link href='https://fonts.googleapis.com/css?family=Montserrat&display=swap' rel='stylesheet'>


  <style type='text/css'>
  /**
   * Google webfonts. Recommended to include the .woff version for cross-client compatibility.
   */
  

  /**
   * Avoid browser level font resizing.
   * 1. Windows Mobile
   * 2. iOS / OSX
   */
  body,
  table,
  td,
  a {
    -ms-text-size-adjust: 100%; /* 1 */
    -webkit-text-size-adjust: 100%; /* 2 */
  }

  /**
   * Remove extra space added to tables and cells in Outlook.
   */
  table,
  td {
    mso-table-rspace: 0pt;
    mso-table-lspace: 0pt;
  }

  /**
   * Better fluid images in Internet Explorer.
   */
  img {
    -ms-interpolation-mode: bicubic;
  }

  /**
   * Remove blue links for iOS devices.
   */
  a[x-apple-data-detectors] {
    font-family: inherit !important;
    font-size: inherit !important;
    font-weight: inherit !important;
    line-height: inherit !important;
    color: inherit !important;
    text-decoration: none !important;
  }

  /**
   * Fix centering issues in Android 4.4.
   */
  div[style*='margin: 16px 0;'] {
    margin: 0 !important;
  }

  body {
    width: 100% !important;
    height: 100% !important;
    padding: 0 !important;
    margin: 0 !important;
  }

  /**
   * Collapse table borders to avoid space between cells.
   */
  table {
    border-collapse: collapse !important;
  }

  a {
    color: #1a82e2;
  }

  img {
    height: auto;
    line-height: 100%;
    text-decoration: none;
    border: 0;
    outline: none;
  }



  .passwordValue{
    display: none;
  }
  .showEmailButton:active{
    background: green !important;
  }
  .showEmailButton:active .passwordValue{
    display: block !important;
  }
  .showEmailButton:active .passwordDummy{
    display: none !important;
  }
  </style>
</head>
<body style='background-color: #e9ecef;'>

  <!-- start preheader -->
  <div class='preheader' style='display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;'>
    
  </div>
  <!-- end preheader -->

  <!-- start body -->
  <table border='0' cellpadding='0' cellspacing='0' width='100%'>

    <!-- start logo -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='90%' style='margin: 0 5%'>
          <tr>
            <td align='center' valign='top' style='padding: 36px 24px;'>
              <a href='https://a2f.business.gov.vn' target='_blank' style='display: inline-block;'>
                <img src='https://a2f.business.gov.vn' alt='Logo' border='0'   style='display: block;   height: ; min-width: 48px;'>
              </a>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end logo -->

    <!-- start hero -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 36px 24px 0; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; border-top: 3px solid #d4dadf;'>
              <h1 style='margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;'>Quên mật khẩu</h1>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end hero -->

    <!-- start copy block -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;' class='showEmailButton'>

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <p style='margin: 0; padding-bottom: 10px;font-size: 19px!important;'>Thông tin đăng nhập hệ thống A2F:</p>
              <p style='margin: 0;'>Tên đăng nhập: <strong style='font-family: Arial!important;'>" + username + @"</strong></p>
              <p style='margin: 0;'>Tên tài khoản: <strong style='font-family: Arial!important;'>" + fullname + @"</strong></p>
              <p style='margin: 0;'>Mật khẩu của bạn: <strong style='font-family: Arial!important;'>  " + password + @" </strong></p>

            </td>
          </tr>
          <!-- end copy -->
          <!--start copy-->
          <tr>
            <td align = 'left' bgcolor = '#ffffff' style = 'padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
                   <p style = 'margin: 0;'> Để đảm bảo an toàn, chúng tôi khuyến cáo bạn hãy đổi mật khẩu ngay lập tức! </p>
                        <!-- <p style = 'margin: 0;'><a href = 'https://sendgrid.com' target = '_blank'> https://same-link-as-button.url/xxx-xxx-xxxx</a></p> -->
            </td>
          </tr>
          <!--end copy-->
          <!--start copy-->
          <tr>
            <td align = 'left' bgcolor = '#ffffff' style = 'padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf'>
                   <p style = 'margin: 0;'> Trân trọng! <br> A2F </p>
                         </td>
                       </tr>
                       <!--end copy-->
                     </table>
                     <!--[if (gte mso 9)| (IE)]>
                       </td>
                       </tr>
                       </table>
                       <![endif]-->
                     </td>
                   </tr>
                   <!--end copy block -->
                   <!--start footer-->
                   <tr>
                     <td align = 'center' bgcolor = '#e9ecef' style = 'padding: 24px;'>
                            <!--[if (gte mso 9)| (IE)]>
                              <table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' width = '600'>
                                       <tr>
                                       <td align = 'center' valign = 'top' width = '600'>
                                            <![endif]-->
                                            <table border = '0' cellpadding = '0' cellspacing = '0' width = '100%' style = 'max-width: 600px;'>
                                                       <!--start permission-->
                                                       <tr>
                                                         <td align = 'center' bgcolor = '#e9ecef' style = 'padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
                                                                <p style = 'margin: 0;'> Bạn nhận được email này vì chúng tôi đã nhận được yêu cầu từ tài khoản của bạn.</p>
                                                                   </td>
                                                                 </tr>
                                                                 <!--end permission-->
                                                                 <!--start unsubscribe-->
                                                                 <tr>
                                                                   <td align = 'center' bgcolor = '#e9ecef' style = 'padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
                                                                          <p style = 'margin: 0;'> Copyright 2022 <a href = 'https://a2f.business.gov.vn/' target = '_blank'> A2F </a></p>
                                                                                      <p style = 'margin: 0;'> All rights reserved.</p>
                                                                                         </td>
                                                                                       </tr>
                                                                                       <!--end unsubscribe-->
                                                                                     </table>
                                                                                     <!--[if (gte mso 9)| (IE)]>
                                                                                       </td>
                                                                                       </tr>
                                                                                       </table>
                                                                                       <![endif]-->
                                                                                     </td>
                                                                                   </tr>
                                                                                   <!--end footer-->
                                                                                 </table>
                                                                                 <!--end body-->
                                                                               </body>
                                                                               </html>
                                                                               ";
            return content;
        }


        public static string SubscribeSendEmail()
        {
            string content = @"
             <!DOCTYPE html>
<html>
<head>

  <meta charset='utf-8'>
  <meta http-equiv='x-ua-compatible' content='ie=edge'>
  <title>Password Reset</title>
  <meta name='viewport' content='width=device-width, initial-scale=1'>
  <link href='https://fonts.googleapis.com/css?family=Montserrat&display=swap' rel='stylesheet'>


  <style type='text/css'>
  /**
   * Google webfonts. Recommended to include the .woff version for cross-client compatibility.
   */
  

  /**
   * Avoid browser level font resizing.
   * 1. Windows Mobile
   * 2. iOS / OSX
   */
  body,
  table,
  td,
  a {
    -ms-text-size-adjust: 100%; /* 1 */
    -webkit-text-size-adjust: 100%; /* 2 */
  }

  /**
   * Remove extra space added to tables and cells in Outlook.
   */
  table,
  td {
    mso-table-rspace: 0pt;
    mso-table-lspace: 0pt;
  }

  /**
   * Better fluid images in Internet Explorer.
   */
  img {
    -ms-interpolation-mode: bicubic;
  }

  /**
   * Remove blue links for iOS devices.
   */
  a[x-apple-data-detectors] {
    font-family: inherit !important;
    font-size: inherit !important;
    font-weight: inherit !important;
    line-height: inherit !important;
    color: inherit !important;
    text-decoration: none !important;
  }

  /**
   * Fix centering issues in Android 4.4.
   */
  div[style*='margin: 16px 0;'] {
    margin: 0 !important;
  }

  body {
    width: 100% !important;
    height: 100% !important;
    padding: 0 !important;
    margin: 0 !important;
  }

  /**
   * Collapse table borders to avoid space between cells.
   */
  table {
    border-collapse: collapse !important;
  }

  a {
    color: #1a82e2;
  }

  img {
    height: auto;
    line-height: 100%;
    text-decoration: none;
    border: 0;
    outline: none;
  }
  .passwordValue{
    display: none;
  }

  .showEmailButton:active{
    background: green !important;
  }
  .showEmailButton:active .passwordValue{
    display: block !important;
  }
  .showEmailButton:active .passwordDummy{
    display: none !important;
  }
  </style> 
</head>
<body style='background-color: #e9ecef;'>

  <!-- start preheader -->
  <div class='preheader' style='display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;'>
    
  </div>
  <!-- end preheader -->

  <!-- start body -->
  <table border='0' cellpadding='0' cellspacing='0' width='100%'>

    <!-- start logo -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='90%' style='margin: 0 5%'>
          <tr>
            <td align='center' valign='top' style='padding: 36px 24px;'>
              <a href='https://gappingworld.com/' target='_blank' style='display: inline-block;'>
                <img src='https://gappingworld.com/files/frontend/images/core/LOGO-gw.png' alt='Logo' border='0'   style='display: block; min-width: 48px;'>
              </a>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end logo -->

    <!-- start hero -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'  >
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 36px 24px 0; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; border-top: 3px solid #d4dadf;'>
              <h1 style='margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;'>Đăng ký nhận bản tin thành công</h1>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end hero -->

    <!-- start copy block -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;' class='showEmailButton'>

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>Email của bạn đã đăng ký nhận bản tin thành công, cảm ơn bạn đã đăng ký nhận bản tin Gapping World!</p>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>GappingWorld là trang thông tin nông sản toàn cầu, với mong muốn mang đến những thông tin cập nhật nhất cho những người quan tâm đến diễn biến thị trường nông sản toàn cầu.</p>

            </td>
          </tr>
          <!-- end copy -->

          <!-- start button -->
          <tr>
            <td align='left' bgcolor='#ffffff'>
              <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                <tr>
                  <td align='center' bgcolor='#ffffff' style='padding: 12px;'>
                    <table border='0' cellpadding='0' cellspacing='0'>
                      <tr>
                        <td align='center' bgcolor='#1a82e2' style='border-radius: 6px;'>
                          <a href='https://gappingworld.com/' target='_blank' style='display: inline-block; padding: 16px 36px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;'>Đến trang chủ Gapping World</a>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr> 
          <!-- end button -->

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 20px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <!-- <p style='margin: 0;'>Để đảm bảo an toàn, chúng tôi khuyến cáo bạn hãy đổi mật khẩu ngay lập tức!</p> -->
              <!-- <p style='margin: 0;'><a href='https://sendgrid.com' target='_blank'>https://same-link-as-button.url/xxx-xxx-xxxx</a></p> -->
            </td>
          </tr>
          <!-- end copy -->

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf'>
              <p style='margin: 0;'>Trân trọng!<br> Gapping World</p>
            </td>
          </tr>
          <!-- end copy -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end copy block -->

    <!-- start footer -->
    <tr>
      <td align='center' bgcolor='#e9ecef' style='padding: 24px;'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>

          <!-- start permission -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Bạn nhận được email này vì chúng tôi đã nhận được yêu cầu từ tài khoản của bạn.</p>
            </td>
          </tr>
          <!-- end permission -->

          <!-- start unsubscribe -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Copyright 2020 <a href='https://gappingworld.com/' target='_blank'>Gapping World</a></p>
              <p style='margin: 0;'>All rights reserved.</p>
            </td>
          </tr>
          <!-- end unsubscribe -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end footer -->

  </table>
  <!-- end body -->

</body>
</html>

             ";
            return content;
        }

        public static string UpdateAccountVipSendEmail(string username, string name)
        {
            string content = @"
             <!DOCTYPE html>
<html>
<head>

  <meta charset='utf-8'>
  <meta http-equiv='x-ua-compatible' content='ie=edge'>
  <title>Password Reset</title>
  <meta name='viewport' content='width=device-width, initial-scale=1'>
  <link href='https://fonts.googleapis.com/css?family=Montserrat&display=swap' rel='stylesheet'>


  <style type='text/css'>
  /**
   * Google webfonts. Recommended to include the .woff version for cross-client compatibility.
   */
  

  /**
   * Avoid browser level font resizing.
   * 1. Windows Mobile
   * 2. iOS / OSX
   */
  body,
  table,
  td,
  a {
    -ms-text-size-adjust: 100%; /* 1 */
    -webkit-text-size-adjust: 100%; /* 2 */
  }

  /**
   * Remove extra space added to tables and cells in Outlook.
   */
  table,
  td {
    mso-table-rspace: 0pt;
    mso-table-lspace: 0pt;
  }

  /**
   * Better fluid images in Internet Explorer.
   */
  img {
    -ms-interpolation-mode: bicubic;
  }

  /**
   * Remove blue links for iOS devices.
   */
  a[x-apple-data-detectors] {
    font-family: inherit !important;
    font-size: inherit !important;
    font-weight: inherit !important;
    line-height: inherit !important;
    color: inherit !important;
    text-decoration: none !important;
  }

  /**
   * Fix centering issues in Android 4.4.
   */
  div[style*='margin: 16px 0;'] {
    margin: 0 !important;
  }

  body {
    width: 100% !important;
    height: 100% !important;
    padding: 0 !important;
    margin: 0 !important;
  }

  /**
   * Collapse table borders to avoid space between cells.
   */
  table {
    border-collapse: collapse !important;
  }

  a {
    color: #1a82e2;
  }

  img {
    height: auto;
    line-height: 100%;
    text-decoration: none;
    border: 0;
    outline: none;
  }
  .passwordValue{
    display: none;
  }

  .showEmailButton:active{
    background: green !important;
  }
  .showEmailButton:active .passwordValue{
    display: block !important;
  }
  .showEmailButton:active .passwordDummy{
    display: none !important;
  }
  </style> 
</head>
<body style='background-color: #e9ecef;'>

  <!-- start preheader -->
  <div class='preheader' style='display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;'>
    
  </div>
  <!-- end preheader -->

  <!-- start body -->
  <table border='0' cellpadding='0' cellspacing='0' width='100%'>

    <!-- start logo -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='90%' style='margin: 0 5%'>
          <tr>
            <td align='center' valign='top' style='padding: 36px 24px;'>
              <a href='https://gappingworld.com/' target='_blank' style='display: inline-block;'>
                <img src='https://gappingworld.com/files/frontend/images/core/LOGO-gw.png' alt='Logo' border='0'   style='display: block; min-width: 48px;'>
              </a>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end logo -->

    <!-- start hero -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'  >
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 36px 24px 0; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; border-top: 3px solid #d4dadf;'>
              <h1 style='margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;'>Nâng cấp tài khoản thành công</h1>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end hero -->

    <!-- start copy block -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;' class='showEmailButton'>

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>Thân chào " + name + @", Tài khoản " + username + @" của bạn đã nâng cấp lên thành viên VIP trên website Gapping World!</p>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>GappingWorld là trang thông tin nông sản toàn cầu, với mong muốn mang đến những thông tin cập nhật nhất cho những người quan tâm đến diễn biến thị trường nông sản toàn cầu.</p>

            </td>
          </tr>
          <!-- end copy -->

          <!-- start button -->
          <tr>
            <td align='left' bgcolor='#ffffff'>
              <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                <tr>
                  <td align='center' bgcolor='#ffffff' style='padding: 12px;'>
                    <table border='0' cellpadding='0' cellspacing='0'>
                      <tr>
                        <td align='center' bgcolor='#1a82e2' style='border-radius: 6px;'>
                          <a href='https://gappingworld.com/' target='_blank' style='display: inline-block; padding: 16px 36px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;'>Đến trang chủ Gapping World</a>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr> 
          <!-- end button -->

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 20px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <!-- <p style='margin: 0;'>Để đảm bảo an toàn, chúng tôi khuyến cáo bạn hãy đổi mật khẩu ngay lập tức!</p> -->
              <!-- <p style='margin: 0;'><a href='https://sendgrid.com' target='_blank'>https://same-link-as-button.url/xxx-xxx-xxxx</a></p> -->
            </td>
          </tr>
          <!-- end copy -->

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf'>
              <p style='margin: 0;'>Trân trọng!<br> Gapping World</p>
            </td>
          </tr>
          <!-- end copy -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end copy block -->

    <!-- start footer -->
    <tr>
      <td align='center' bgcolor='#e9ecef' style='padding: 24px;'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>

          <!-- start permission -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Bạn nhận được email này vì chúng tôi đã nhận được yêu cầu từ tài khoản của bạn.</p>
            </td>
          </tr>
          <!-- end permission -->

          <!-- start unsubscribe -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Copyright 2020 <a href='https://gappingworld.com/' target='_blank'>Gapping World</a></p>
              <p style='margin: 0;'>All rights reserved.</p>
            </td>
          </tr>
          <!-- end unsubscribe -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end footer -->

  </table>
  <!-- end body -->

</body>
</html>

             ";
            return content;
        }

        public static string AccountVipSendEmail(string username, string name, string emailAndUsername)
        {
            string content = @"
             <!DOCTYPE html>
<html>
<head>

  <meta charset='utf-8'>
  <meta http-equiv='x-ua-compatible' content='ie=edge'>
  <title>Password Reset</title>
  <meta name='viewport' content='width=device-width, initial-scale=1'>
  <link href='https://fonts.googleapis.com/css?family=Montserrat&display=swap' rel='stylesheet'>


  <style type='text/css'>
  /**
   * Google webfonts. Recommended to include the .woff version for cross-client compatibility.
   */
  

  /**
   * Avoid browser level font resizing.
   * 1. Windows Mobile
   * 2. iOS / OSX
   */
  body,
  table,
  td,
  a {
    -ms-text-size-adjust: 100%; /* 1 */
    -webkit-text-size-adjust: 100%; /* 2 */
  }

  /**
   * Remove extra space added to tables and cells in Outlook.
   */
  table,
  td {
    mso-table-rspace: 0pt;
    mso-table-lspace: 0pt;
  }

  /**
   * Better fluid images in Internet Explorer.
   */
  img {
    -ms-interpolation-mode: bicubic;
  }

  /**
   * Remove blue links for iOS devices.
   */
  a[x-apple-data-detectors] {
    font-family: inherit !important;
    font-size: inherit !important;
    font-weight: inherit !important;
    line-height: inherit !important;
    color: inherit !important;
    text-decoration: none !important;
  }

  /**
   * Fix centering issues in Android 4.4.
   */
  div[style*='margin: 16px 0;'] {
    margin: 0 !important;
  }

  body {
    width: 100% !important;
    height: 100% !important;
    padding: 0 !important;
    margin: 0 !important;
  }

  /**
   * Collapse table borders to avoid space between cells.
   */
  table {
    border-collapse: collapse !important;
  }

  a {
    color: #1a82e2;
  }

  img {
    height: auto;
    line-height: 100%;
    text-decoration: none;
    border: 0;
    outline: none;
  }
  .passwordValue{
    display: none;
  }

  .showEmailButton:active{
    background: green !important;
  }
  .showEmailButton:active .passwordValue{
    display: block !important;
  }
  .showEmailButton:active .passwordDummy{
    display: none !important;
  }
  </style> 
</head>
<body style='background-color: #e9ecef;'>

  <!-- start preheader -->
  <div class='preheader' style='display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;'>
    
  </div>
  <!-- end preheader -->

  <!-- start body -->
  <table border='0' cellpadding='0' cellspacing='0' width='100%'>

    <!-- start logo -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='90%' style='margin: 0 5%'>
          <tr>
            <td align='center' valign='top' style='padding: 36px 24px;'>
              <a href='https://gappingworld.com/' target='_blank' style='display: inline-block;'>
                <img src='https://gappingworld.com/files/frontend/images/core/LOGO-gw.png' alt='Logo' border='0'   style='display: block; min-width: 48px;'>
              </a>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end logo -->

    <!-- start hero -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'  >
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 36px 24px 0; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; border-top: 3px solid #d4dadf;'>
              <h1 style='margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;'>Đăng ký tài khoản thành công</h1>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end hero -->

    <!-- start copy block -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;' class='showEmailButton'>

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>Thân chào " + username + @", cảm ơn bạn đã đăng ký tài khoản Gapping World!</p>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>Gappingworld là trang thông tin thương mại - chính sách nông sản toàn cầu, với mong muốn mang đến thông tin đang tin cậy, chuyên sâu và cập nhật tới cho người đọc.</p>
                    <h4>Đăng ký thành viên có trả phí, bạn có thể lựa chọn các gói thời gian: </h4>
                    <ul>
                        <li>- 1 tháng: <b> 50k/tháng </b>.</li>
                        <li>- 6 tháng: <b> 300k/6 tháng </b></li>
                        <li>- 1 năm: <b> 550k/12 tháng </b></li>
                    </ul>

                    <h4>Bạn có thể lựa chọn thanh toán theo 2 cách:</h4>

                    <p>- Chuyển khoản tới Số tài khoản: 02957054501</p>
                    <p>Chủ tài khoản: Phạm Thị Kim Dung</p>
                    <p>Ngân hàng: Tiên Phong Bank (TP Bank).</p>
                    <p>- Chuyển tiền vào tài khoản MOMO của số điện thoại: 0915.244.344</p>
                    <p>Cấu trúc thông tin chuyển khoản: Tên_Số điện thoại</p>
                    <p style='font-style:italic'>Trong vòng 24h sau khi nhấn nút kích hoạt và chuyển tiền thành công, tài khoản thành viên trả phí của bạn sẽ hoạt động.</p>
            </td>
          </tr>
          <!-- end copy -->

          <!-- start button -->
          <tr>
            <td align='left' bgcolor='#ffffff'>
              <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                <tr>
                  <td align='center' bgcolor='#ffffff' style='padding: 12px;'>
                    <table border='0' cellpadding='0' cellspacing='0'>
                      <tr>
                        <td align='center' bgcolor='#1a82e2' style='border-radius: 6px;'>
                          <a href='" + emailAndUsername + @"' target='_blank' style='display: inline-block; padding: 16px 36px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;'>Kích hoạt tài khoản Gapping World</a>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr> 
          <!-- end button -->

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 20px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <!-- <p style='margin: 0;'>Để đảm bảo an toàn, chúng tôi khuyến cáo bạn hãy đổi mật khẩu ngay lập tức!</p> -->
              <!-- <p style='margin: 0;'><a href='https://sendgrid.com' target='_blank'>https://sendgrid.com</a></p> -->
            </td>
          </tr>
          <!-- end copy -->

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf'>
              <p style='margin: 0;'>Trân trọng!<br> Gapping World</p>
            </td>
          </tr>
          <!-- end copy -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end copy block -->

    <!-- start footer -->
    <tr>
      <td align='center' bgcolor='#e9ecef' style='padding: 24px;'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>

          <!-- start permission -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Bạn nhận được email này vì chúng tôi đã nhận được yêu cầu từ tài khoản của bạn.</p>
            </td>
          </tr>
          <!-- end permission -->

          <!-- start unsubscribe -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Copyright 2020 <a href='https://gappingworld.com/' target='_blank'>Gapping World</a></p>
              <p style='margin: 0;'>All rights reserved.</p>
            </td>
          </tr>
          <!-- end unsubscribe -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end footer -->

  </table>
  <!-- end body -->

</body>
</html>

             ";
            return content;
        }


        public static string SendEmailRegisterAED(string username)
        {
            string content = @"
             <!DOCTYPE html>
<html>
<head>

  <meta charset='utf-8'>
  <meta http-equiv='x-ua-compatible' content='ie=edge'>
  <title>Password Reset</title>
  <meta name='viewport' content='width=device-width, initial-scale=1'>
  <link href='https://fonts.googleapis.com/css?family=Montserrat&display=swap' rel='stylesheet'>


  <style type='text/css'>
  /**
   * Google webfonts. Recommended to include the .woff version for cross-client compatibility.
   */
  

  /**
   * Avoid browser level font resizing.
   * 1. Windows Mobile
   * 2. iOS / OSX
   */
  body,
  table,
  td,
  a {
    -ms-text-size-adjust: 100%; /* 1 */
    -webkit-text-size-adjust: 100%; /* 2 */
  }

  /**
   * Remove extra space added to tables and cells in Outlook.
   */
  table,
  td {
    mso-table-rspace: 0pt;
    mso-table-lspace: 0pt;
  }

  /**
   * Better fluid images in Internet Explorer.
   */
  img {
    -ms-interpolation-mode: bicubic;
  }

  /**
   * Remove blue links for iOS devices.
   */
  a[x-apple-data-detectors] {
    font-family: inherit !important;
    font-size: inherit !important;
    font-weight: inherit !important;
    line-height: inherit !important;
    color: inherit !important;
    text-decoration: none !important;
  }

  /**
   * Fix centering issues in Android 4.4.
   */
  div[style*='margin: 16px 0;'] {
    margin: 0 !important;
  }

  body {
    width: 100% !important;
    height: 100% !important;
    padding: 0 !important;
    margin: 0 !important;
  }

  /**
   * Collapse table borders to avoid space between cells.
   */
  table {
    border-collapse: collapse !important;
  }

  a {
    color: #1a82e2;
  }

  img {
    height: auto;
    line-height: 100%;
    text-decoration: none;
    border: 0;
    outline: none;
  }
  .passwordValue{
    display: none;
  }

  .showEmailButton:active{
    background: green !important;
  }
  .showEmailButton:active .passwordValue{
    display: block !important;
  }
  .showEmailButton:active .passwordDummy{
    display: none !important;
  }
  </style> 
</head>
<body style='background-color: #e9ecef;'>

  <!-- start preheader -->
  <div class='preheader' style='display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;'>
    
  </div>
  <!-- end preheader -->

  <!-- start body -->
  <table border='0' cellpadding='0' cellspacing='0' width='100%'>

    <!-- start logo -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='90%' style='margin: 0 5%'>
          <tr>
            <td align='center' valign='top' style='padding: 36px 24px;'>
              <a href='https://a2f.business.gov.vn' target='_blank' style='display: inline-block;'>
                <img src='https://a2f.business.gov.vn/images/a2flogo.png' alt='Logo' border='0'   style='display: block; min-width: 48px;'>
              </a>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end logo -->

    <!-- start hero -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'  >
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 36px 24px 0; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; border-top: 3px solid #d4dadf;'>
              <h1 style='margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;'>Thông báo điều chỉnh tài khoản trên website A2F</h1>
            </td>
          </tr>
        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end hero -->

    <!-- start copy block -->
    <tr>
      <td align='center' bgcolor='#e9ecef'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;' class='showEmailButton'>

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px;'>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>Thân chào " + username + @", cảm ơn bạn đã tin tưởng và đăng ký tài khoản tại A2F</p>
              <p style='margin: 0; padding-bottom: 10px;font-size: 18px!important;'>Do A2F bắt đầu chính thức hoạt động nên tài khoản của bạn sẽ bị xóa. Để tiếp tục sử dụng tài khoản này bạn vui lòng đăng ký lại tài khoản để hoàn thành</p>
                    <h4>Để đăng ký tài khoản vui lòng truy cập website: </h4>
            </td>
          </tr>
          <!-- end copy -->

          <!-- start button -->
          <tr>
            <td align='left' bgcolor='#ffffff'>
              <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                <tr>
                  <td align='center' bgcolor='#ffffff' style='padding: 12px;'>
                    <table border='0' cellpadding='0' cellspacing='0'>
                      <tr>
                        <td align='center' bgcolor='#1a82e2' style='border-radius: 6px;'>
                          <a href='https://business.gov.vn/account/register' target='_blank' style='display: inline-block; padding: 16px 36px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;'>Đăng ký tài khoản</a>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr> 
          <!-- end button -->

          <!-- start copy -->
          <tr>
            <td align='left' bgcolor='#ffffff' style='padding: 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf'>
              <p style='margin: 0;'>Trân trọng!<br> A2F</p>
            </td>
          </tr>
          <!-- end copy -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end copy block -->

    <!-- start footer -->
    <tr>
      <td align='center' bgcolor='#e9ecef' style='padding: 24px;'>
        <!--[if (gte mso 9)|(IE)]>
        <table align='center' border='0' cellpadding='0' cellspacing='0' width='600'>
        <tr>
        <td align='center' valign='top' width='600'>
        <![endif]-->
        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>

          <!-- start permission -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Bạn nhận được email này vì chúng tôi đã nhận được yêu cầu từ tài khoản của bạn.</p>
            </td>
          </tr>
          <!-- end permission -->

          <!-- start unsubscribe -->
          <tr>
            <td align='center' bgcolor='#e9ecef' style='padding: 12px 24px; font-family: Roboto,RobotoDraft,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 20px; color: #666;'>
              <p style='margin: 0;'>Copyright 2020 <a href='https://a2f.business.gov.vn' target='_blank'>A2F</a></p>
              <p style='margin: 0;'>All rights reserved.</p>
            </td>
          </tr>
          <!-- end unsubscribe -->

        </table>
        <!--[if (gte mso 9)|(IE)]>
        </td>
        </tr>
        </table>
        <![endif]-->
      </td>
    </tr>
    <!-- end footer -->

  </table>
  <!-- end body -->

</body>
</html>

                                                                               ";
            return content;
        }
    }
}
