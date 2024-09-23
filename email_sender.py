import os
import smtplib
from email import encoders
from email.mime.base import MIMEBase
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText

# Email credentials
SENDER_EMAIL = "@gmail.com"
SENDER_PASSWORD = ""
SMTP_SERVER = "smtp.your_email_provider.com"
SMTP_PORT = 587

# Send email with certificate
def send_certificate_email(attendee_email, attendee_name, certificate_path):
    msg = MIMEMultipart()
    msg['From'] = SENDER_EMAIL
    msg['To'] = attendee_email
    msg['Subject'] = "Your Attendance Certificate"
    
    body = f"Hi {attendee_name},\n\nPlease find attached your attendance certificate for the recent webinar."
    msg.attach(MIMEText(body, 'plain'))
    
    # Attach certificate
    with open(certificate_path, "rb") as attachment:
        part = MIMEBase('application', 'octet-stream')
        part.set_payload(attachment.read())
        encoders.encode_base64(part)
        part.add_header('Content-Disposition', f'attachment; filename= {os.path.basename(certificate_path)}')
        msg.attach(part)
    
    # Send email
    server = smtplib.SMTP(SMTP_SERVER, SMTP_PORT)
    server.starttls()
    server.login(SENDER_EMAIL, SENDER_PASSWORD)
    server.send_message(msg)
    server.quit()

# Main function to send certificates
def send_certificates(certificates):
    for attendee_email, attendee_name, certificate_path in certificates:
        send_certificate_email(attendee_email, attendee_name, certificate_path)
        print(f"Certificate sent to {attendee_name} ({attendee_email})")

if __name__ == "__main__":
    from certificate_generator import generate_certificates_for_all
    certificates = generate_certificates_for_all()
    send_certificates(certificates)
