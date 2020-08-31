# hu_assesment

Each deployment contains three containers:
1)Front End - UI
2)Back_End - APIs for UI
3)MongoDB - database for saving forms and subnissions.

Deployment can be perform in few ways:

1) Using docker-compose.yaml from root directory "hu_assesment"
  In this case docker-compose pull the images that I prepared from public repositories in Docker Hub. This way is faster.
  Just run from the folder where is the docker-compose.yaml exist: docker-compose -f .\docker-compose.yaml up
  
2) Using two different docker-composes:
    a) from hu_assesment/Form_Builder/docker-compose.yaml - it will build and run docker container for back_end and MongoDB.
      Before running this yaml, the back_end solution must be compiled and published by command: 
      dotnet publish -c Release
      
    b) then after back_end and MongoDB containers are running, from hu_assesment/UI_Form_Builder/docker-compose.yaml should be run too.
    This action will take a bit time because it install all dependencies of the UI.

After all containers created and run, UI page can be open in a browser: http//localhost:3000.
Doesn't matter which one of the ways you'll be prefer for deployment, the UI exposed on: http//localhost:3000.

In the beginning there aren't any form, so by pressing on "Add New Form" will be performed navigation to page for creating form: http://localhost:3000/form_builder
I know about issues on this page but if perform actions in right sequense it works in  right way.
On this page:
1. Press on button Add Field to create a new field
2.1 Enter all inputs in apeared form and sbmit this field by pressing save button
2.2 If you want to add one more field then perform 1.
2.3 else go to 3.
3. Enter name for the form and press save

If new form doesn't appears in list of form try to refresh the page.






