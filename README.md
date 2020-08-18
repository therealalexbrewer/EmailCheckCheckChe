# EmailCheckCheckChe

## Purpose

The idea of this project is to build a simple bot that actively listens for new emails coming in. If it does find one, it will check the email for negative keywords. If one is found, it generates an email to write back to the sender inquiring about what skills can be worked on. This provides not only a nice way to relieve the stress of ambiguous emails, but it additionally adds an extra insightful step of learning more about what to work on in the job market. This bot is great because it is always listening for emails and quickly writes back if it gets a negative email.

## Usage

To use the bot for yourself, copy this repository and open the project as a console application in Visual Studio. Change each instance of "xxxx@gmail.com" to your email. Change the "password" to your password. You can additionally add your phone number if it supports receiving emails. Launch the application and it will begin listening for messages! All of the 'intense code' is within the EmailCheckCheckche.Core DLL. 

## Security

If you're concerned about security, it uses ActiveUp.Net.Mail and System.Net.Mail. Read up on these and enter your information as comfortable. Additionally, you will need to "Allow Less Secure Apps" on your email account. Again, only change this if you're comfortable with doing so.

## Thank Yous

Special thanks to Stack Overflow, ActiveUp.Net.Mail, System.Net.Mail, and my father for helping make this possible. The help from these sites and resources made working on the project enjoyable and great!

## Future Plans

More Negative keywords to be added. Potential input of username/password to be added to the console app so as to mainstream it more towards common end-users with no know-how of C# and coding.
