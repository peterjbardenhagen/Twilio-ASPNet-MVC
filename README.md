# Twilio-ASPNet-MVC

Twilio-ASPNet-MVC built in Visual Studio using .Net Framework 4.7.2

This part of the demo receives a postback response from Twilio when sending a message. It must be hosted on a website that is available on the Internet.

For the purpose of demo I have set the statusCallbackURL to http://149.28.176.193:8080/Home/PostStatus

http://149.28.176.193:8080/Home/Status shows the most recent delivery status and is refreshed automatically when it receives a new status update

Each time a status is received from Twilio via the PostStatus route, the latest status is simply stored in a text file

While the Status page is open, every 1.5 seconds AXIOS makes a call to GetStatus route to check for a new delivery status update to display without refreshing the web page
