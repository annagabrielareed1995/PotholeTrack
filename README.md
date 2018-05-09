# PotholeTrack
San Diego Pothole Trackers

Intro

This web application is used to track the potholes located around our wonderful city of San Diego. As citizens of San Diego, we care about
our streets and want to make sure our town is as beautiful as it can be. For our Senior Design Project, we created a Pothole Detection 
system that utilizes LiDAR sensors and the OpenMV camera. Upon detection, the system will save the latitude and longitude coordinates at 
that location. We wanted to create this website to work in harmony with that system, where we can document the potholes that would be found
using that system into one convenient location. The end user of this application is the City of San Diego, so that they have one data base 
available to them where they can located the potholes around the city. Using the images of the potholes, they can see which ones are of the 
highest priority to fix. We also wanted to include a forum in this web application where residents/users can document potholes that perhaps 
our project design did not see yet. Regular users can add the pictures and location of their pothole, but only the City/admin can delete 
the instance of a pothole (ideally after it has been fixed). 

Developers

The team who built this website consists of Anna Reed, Michael Baker, and Raffy Guiao. We are all Seniors graduating this May of 2018. We 
look forward to completing finals and starting our full-time post-graduate careers! If you have any questions for us, please refer to the
contact page and reach out to us!

Problems

For the PotholeTrack we started off with larger goals than we could accomplish. Initially the plan was to have users submit the latitude
and longitude for a pothole with a .jpg file showing an image of the pothole. The administrator was supposed to upload pothole data 
collected from a pothole detection system we created for Senior Design. The data from the pothole detection system would be considered 
valid. User submitted data would be considered less valid. If a user reported a pothole at the same location as the pothole detection 
system, then the pothole would be considered validated. The site was supposed to leverage available APIs to display a map with pothole
locations identified on the map. In the end we were able to get user text responses on a form. 

- There is a tutorial on ASP.NET for uploading images, but we had no luck with successfully getting a functional version of the uploaded 
.jpg in the code. 

- Michael Baker was stumped on successfully getting 2 database contexts to function, but Anna Reed overcame that issue. We have one 
database that contains user data and a second for pothole data.

- We attempted to use roles/authorization in order to have two levels of users. A public user has not logged in and can only view data
about potholes. A logged in user can creat/edit/delete potholes. We were unsuccessfull in implememting an overall admin to control
user's roles. Modifications to the user's roles has to be done in the database.

- We attempted to seed users into the database, so that different users were preloaded, but the attempt was only partially successful. 
When seeding users, we were only successfull at getting one user seeded. The way the database is set up for the users, a hashed 
password can be entered into the database. The hashed password we entered into the database was not the expected password, so the 
account was inaccessible. In order to demonstrate different users we have to manually create the users on the Azure site.
