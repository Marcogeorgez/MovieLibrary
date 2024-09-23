# Certificate Email Sender

This project generates and sends attendance certificates via email using Python.
It reads attendee information from a CSV file, creates certificates based on a template, and sends them as attachments.

# Table of Contents
- Requirements
- Setup
- Usage
- Code Structure
- License

# Requirements
-Python 3.x
-Required libraries:
    -Pillow for image manipulation
    -smtplib for sending emails
    -csv for reading CSV files

# Setup
1-Email Configuration:
    *Update the following variables in the code with your email details:
        SENDER_EMAIL = "your_email@gmail.com"
        SENDER_PASSWORD = "your_password"
        SMTP_SERVER = "smtp.your_email_provider.com"
        SMTP_PORT = 587
2-Create a CSV file named attendees.csv with the following structure:
        Name,Email
        John Doe,johndoe@example.com
        Jane Smith,janesmith@example.com
3-Directory for Certificates:
    The certificates will be saved in the specified directory in the code. Update the path as needed:
        certificates_dir = r"./certificate_path"


        
#License

This project is open-source. Feel free to modify and use it as needed!