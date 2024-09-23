import csv
import uuid
import os
from PIL import Image, ImageDraw, ImageFont

# Path to certificate template and font
CERTIFICATE_TEMPLATE_PATH = r"certificate_template.png"
FONT_PATH_NAME = r"Fonts\Arial-Regular.TTF"
FONT_PATH = r"Fonts\LCALLIG.TTF"
FONT_SIZE = 60
FONT_GUID = ImageFont.truetype(FONT_PATH_NAME, 16)


# Read attendees from CSV file
def read_attendees_from_csv(file_path):
    attendees = []
    with open(file_path, newline='', encoding='utf-8') as csvfile:
        reader = csv.DictReader(csvfile)
        for row in reader:
            attendees.append({
                'name': row['Name'],
                'email': row['Email']
            })
    return attendees

# Function to draw attendee name with adjustable spacing
def draw_attendee_name(draw, font, attendee_name, position, desired_width):
    # Split the name into words
    words = attendee_name.split()
    
    # Calculate total width with default spacing
    default_spacing = 10  # Adjust this value for your desired spacing
    total_width = sum(draw.textsize(word, font=font)[0] for word in words) + (default_spacing * (len(words) - 1))
    
    if total_width < desired_width:
        # Calculate extra space needed
        extra_space = desired_width - total_width
        # Calculate new spacing
        new_spacing = default_spacing + extra_space / (len(words) - 1) if len(words) > 1 else default_spacing
        
        # Draw text with adjusted spacing
        x_position = position[0]  # X coordinate
        y_position = position[1]  # Y coordinate
        for word in words:
            draw.text((x_position, y_position), word, font=font, fill="black")
            x_position += draw.textsize(word, font=font)[0] + new_spacing
    else:
        # If the total width is already greater than desired, just draw normally
        draw.text(position, attendee_name, font=font, fill="black")

# Generate certificate
def generate_certificate(attendee_name):
    img = Image.open(CERTIFICATE_TEMPLATE_PATH)
    draw = ImageDraw.Draw(img)
    font = ImageFont.truetype(FONT_PATH, FONT_SIZE)
    
    # Adjust position and draw the name using the new function
    name_position = (400, 455)  # Change this based on template
    desired_width = 325  # Example width; adjust to fit your template
    draw_attendee_name(draw, font, attendee_name, name_position, desired_width)

    # Add GUID below the name
    guid_position = (145, 815)
    guid = uuid.uuid5(uuid.NAMESPACE_DNS, attendee_name)  # Ensure a valid namespace is used
    draw.text(guid_position, str(guid), font=FONT_GUID, fill="black")    
    
    # Specify the directory where certificates will be saved
    certificates_dir = r"./certificate_path"  # Change to desired directory
    os.makedirs(certificates_dir, exist_ok=True)

    # Save the certificate to the specified directory
    certificate_path = os.path.join(certificates_dir, f"{attendee_name}_certificate.png")
    img.save(certificate_path)
    
    return certificate_path

# Main function to process attendees and generate certificates
def generate_certificates_for_all():
    attendees = read_attendees_from_csv(r'attendees.csv')  # Path to your CSV file
    
    certificates = []
    for attendee in attendees:
        attendee_name = attendee['name']   
        # Generate certificate
        certificate_path = generate_certificate(attendee_name)
        certificates.append((attendee['email'], attendee_name, certificate_path))
        
    return certificates

if __name__ == "__main__":
    generate_certificates_for_all()
