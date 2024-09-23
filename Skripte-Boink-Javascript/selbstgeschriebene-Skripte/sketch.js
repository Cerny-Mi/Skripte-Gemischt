/*

_________________sources START


//Hinweise zur Nutzung:
-muss in Firefox geöffnet werden. Öffnung in Edge oder Chrome erzeugen Fehler und Sicherheitsschranken.


//for matterjs:
https://www.youtube.com/watch?v=W-ou_sVlTWk

//for cam:
https://p5js.org/examples/dom-video-capture.html
https://editor.p5js.org/benmoren/sketches/keInQabKas
https://editor.p5js.org/ach549@nyu.edu/sketches/S1u1JKeT7
https://www.youtube.com/watch?v=Joy4NQPIOxk
aka:
https://editor.p5js.org/jeffThompson/sketches/30YhUmgVU

//for reversing cam:
https://editor.p5js.org/creativecoding/sketches/0JBTBmvGb
https://forum.processing.org/two/discussion/22546/how-do-i-flip-video-in-canvas-horizontally-in-p5js.html

//getting keyboard input:
https://p5js.org/examples/input-keyboard.html
//switch statements in js:
https://www.w3schools.com/js/js_switch.asp

//text in p5:
https://p5js.org/examples/typography-words.html

//getting color of 1 specific pixel:
https://stackoverflow.com/questions/69679284/how-to-get-the-color-of-a-single-pixel-in-p5js



//Fibonacci Spiral (für obstacles):
https://www.youtube.com/watch?v=uQXUazMvSCw

//Tracking code made by: Eduardo Lundgren 
https://editor.p5js.org/MichelleCerny/sketches/beQ1JybLOs

_________________sources END   


*/



// Note that the syntax has been updated to use object destructuring
const { Engine, World, Bodies, Events, Composite, Collision, Mouse } = Matter;

//____________publics START
let engine;
let world;
let particles = [];
let boundaries = [];
let colorRectKids = [];
let headPositionStash = [];
let obstacles = [];
let crosses = [];
let rects = [];
let sGoalPositions = [];

//"objects"
let boundHeight = 20; //height/thickness of boundaries;
let sCirc; //Steuerball
let sGoal; //where the user is supposed to go
let myHead; //Kopfdarstellung in p5
let ballCatcher;

let vecRestart;
let headColor;
let restartX, restartY;
let restartCross, cameraCross, helperCross;

//bools:
//let _collided= false;
let _hideHelperDrawing = true;
let _camVisualized = false; //whether or not you see the camerafeed (as a user)
let _mirroredMovement = false;
let  _newValueUsable = true;
let _success = false;

//color detection without mouse
let detector;
let vidDet;

let degree = 1;
let brightness = 1;
let obstacleBrightness = 10;
let brightnessAdder = 3;
let _adds;


//video capture:
let videoFeed;
let trackedX, trackedY;

//1920 * 927
//defining default values, in case  user uses "abbrechen" on both starting prompts!
let canW =1920 ; 
let canH=927;
let screenFormatInt = 1; 
let colorChoice = "b"; 
let lim;
// text;
let font;
let fontsize = 30;
let successcounter = 0;
let startText = "";

//positionArray Head:
//let oPos, mPos, nPos, durchschnitt;
//let threshhold = 50; //amount of pixels new pos of head is allowed to stray away from the old pos before the head is considered "unnaturally out of bounds"

//obstacles in a line:
let firstObstacle, lastObstacle;
let iObs;

let n = 40; //amount of recs
let iRect;
let thick, objectThick;
//let s = 200; //screen size for the spiral orientation

    let obstAngle= 0;

    //true = value ++; false = value --
 let _boolXAdd = true;   
 let _boolYAdd = false;  
 let newOX, newOY, xOff, yOff;



//Tracking code made by: Eduardo Lundgren 

let colors;
let chosenColor = "yellow";
let capture;
let trackingData;
let wi = 30;

let sCircSizeControl; 
let successHue; 



function setup() {



////

angleMode(DEGREES)
 successHue=  random(1,360);
   

//FORMATE ZU BEGINN:
lim = 4;
//screenFormatInt = prompt("Wähle ein Level von 1 bis "+lim+":", 1);
colorChoice = prompt("Trackingfarbe Gelb [g] oder Blau [b] ?", "g");

  
if(colorChoice=="b"){

  chosenColor = "cyan"; 


}

else if(colorChoice=="g"){
  chosenColor = "yellow";

}
else {chosenColor = "cyan";
}
    
    
    
 //to not see the cursor after color selection
    document.body.style.cursor = 'none';

    

  
  if(screenFormatInt==1){

    canW = window.innerWidth;
    canH = window.innerHeight;

    console.log("'fullscreen'", canW, canH);   

  }

  else if(screenFormatInt==2){
    canW=1366;
    canH= 768;

    //TV-Format stattdessen: 1920 * 927
    console.log("'Laptop-Format'",canW, canH);
  }

  else if(screenFormatInt==3){
    canW=400;
    canH=400;
    console.log("'400*400'",canW, canH);
  }

  else if (screenFormatInt==4){
    canH=400;
    canW = window.innerWidth;
    console.log("'400*fullscreen'", canW, canH);
    
  }

  else if (screenFormatInt>lim){
    console.log("Die angegebene Nummer ist nicht vertreten");
  }




  //for the restart cross
  //needs flexible code!
  restartX = canW / 4;
  restartY = canH / 10;

  //one obstacle to start
  thick = canH * 0.01;
  objectThick = canH * 0.08;
    sCircSizeControl= objectThick*0.25;
    
    
  engine = Engine.create();
  world = engine.world;


////


createCanvas(canW,canH)

capture = createCapture(VIDEO); //capture the webcam
capture.position(0,0) //move the capture to the top left
capture.style('opacity',0)// use this to hide the capture later on (change to 0 to hide)...
//capture.hide();
capture.id("myVideo"); //give the capture an ID so we can use it in the tracker below.
capture.size(canW, canH);
 //colors = new tracking.ColorTracker(['magenta', 'cyan', 'yellow']);
 //chosenColor= "yellow";
  colors = new tracking.ColorTracker([chosenColor]); //'cyan'

tracking.track('#myVideo', colors); // start the tracking of the colors above on the camera in p5

//start detecting the tracking
colors.on('track', function(event) { //this happens each time the tracking happens
    trackingData = event.data // break the trackingjs data into a global so we can access it with p5
});


  myHead = new Head(canW/2, canH/2, objectThick*0.8);
  sGoal = new Particle(canW/2, canH/2, objectThick*0.3, 0, true); //only there once and doesnt respawn
  ballCatcher = new Boundary(restartX/4, restartY + canH/10, canW/50, canH/100, 0, true);
  sCirc = new Particle(restartX/4, restartY+ canH/12, sCircSizeControl, random(10,360), false); //stat canw vorher 10
  


    //other objects spawn:

    push()
    colorMode(HSB, 360, 100, 100); // Switch to HSB mode
    firstObstacle = obstacles.push(
      new Obstacle(
       canW/2 - objectThick,
        canH/2 + objectThick,
        thick,
        100, 1 ,obstacleBrightness // = color declaration of the first drawn obstacle!
        

        //if colorful instead:  66, 57, 97
      )
    );
    pop()
    initObstacles(n);
    console.log(n, obstacles.length);


    
  /////////////////MATTER EVENT START


  function collision(event) {
    var pairs = event.pairs;
    for (var i = 0; i < pairs.length; i++) {
      var labelA = pairs[i].bodyA.label;
      var labelB = pairs[i].bodyB.label;

      //checking for ball-obstacle collision (=restart)
      if (
        (labelA == "ball" && labelB == "obstacle") ||
        (labelA == "obstacle" && labelB == "ball")
      ) {
         // console.log("ball collided with obstacle");
          destroyAndCreate(); //to reset scirc
          _success = false;
          

      } //if END


//checking for ball-pass collision (=coloring in the obstacle)
if (
  (labelA == "ball" && labelB == "pass") ||
  (labelA == "pass" && labelB == "ball")
) {
   // console.log("ball passed an obstacle");
    if(labelA == "pass"){
      pairs[i].bodyA.color = color(random(0,360), random(50,100), random(50,100) );
      //console.log(pairs[i].bodyA.isSensor);
    }
    if(labelB == "pass"){
      pairs[i].bodyB.color = color(random(0,360), random(50,100), random(50,100) );
     
    }

} //if END

//ball scirc meets ball sground
if (labelA == "ball" && labelB == "ball") {
   // console.log("ball collided with obstacle");
   console.log("success!"); 
   _success = true;
  
  successcounter++;
    sCircSizeControl= sCircSizeControl-0.05 ; 
    sCirc.body.r = sCircSizeControl; 
    console.log(sCirc.body.r);
   sGoal.removeFromWorld();//deletes the old

   sGoal = new Particle(random(canW/10, canW/1.7), random(canH/10, canH/1.7), objectThick*0.3, 0, true); //only there once and doesnt respawn
    //don't let the sgoal-positions be random!!!

      //spawn more obstacles to make every round harder:
    
    
    /*
     for (let i = 0; i < 5; i++) {
        obstacles.push(new Obstacle (random(restartX, canW), random(restartY, canH), random(thick/3, thick*2.5), 100, 1 ,50 )); }
    */
    
   
     
     
//success color!
    
successHue= successHue + random(1,20);
    
if(successHue >= 360) successHue=0; 
    
    initObstacles(10); console.log(obstacles.length);
  
   for (let i = 0; i < obstacles.length; i++) {
    obstacles[i].successColoring(successHue);
  }
    
    


  _success = false;
  
} //if END
 } //for END
  } //event function END


  Events.on(engine, "collisionStart", collision);
  /////////////////////MATTER EVENT END





}//SETUP END






function draw() {

  background(0);


  push();
  translate(width, 0); // move to far corner
  scale(-1.0, 1.0); // flip x-axis backwards
  if (_camVisualized) { image(capture, 0, 0);}
  pop();
  

  Engine.update(engine);


  sGoal.show();
  ballCatcher.show();
  
  for (let i = 0; i < obstacles.length; i++) {
    obstacles[i].show();
  }



  if(sCirc!=undefined) {sCirc.show();

    //console.log(sCirc.body.position.y, sCirc.body.position.x);
    //sCirc.y is NOT the same as  sCirc.body.position.y!!!!
    //sCirc.y = the normal p5-ellipse, which doesnt move because its coordinate system is the one moving!
    //sCirc.body.position.y = the matter.js-body, which is the one doing all the moving!!
  
    if(sCirc.body.position.y >= (canH-40) || sCirc.body.position.x <=  0 ){  destroyAndCreate(); }

    //console.log("destroy circ because it left field!");
  
  
  }


  if(trackingData && trackingData[0]!=undefined){ //if there is tracking data to look at, then...
    

    myHead.updatePosition(trackingData[0].x,trackingData[0].y);


    /*
    for (let i = 0; i < trackingData.length; i++) { //loop through each of the detected colors
      // console.log( trackingData.length )
     // rect(trackingData[i].x,trackingData[i].y,objectThick,objectThick);
      myHead.updatePosition(trackingData[i].x,trackingData[i].y);
     
    }//forEND
    */

    

  }//ifEND


  if(!trackingData || trackingData[0]==undefined ){
//show text


noStroke();
textSize(canW*0.015);
//content, x, y
textAlign(CENTER);

colorMode(HSB);
if(chosenColor == "yellow") {
  fill(61, 100, 90);
 startText="Halte ein gelbes Objekt vor den Bildschirm."
}
else if (chosenColor == "cyan"){
  fill(200, 100, 90);
  startText= "Halte ein blaues Objekt vor den Bildschirm."
  }


  text(startText, canW/2, canH/2.5);

  }


}//DRAW END






function destroyAndCreate() {
  if (sCirc != undefined) sCirc.removeFromWorld();

  //create the new
  sCirc = new Particle(restartX/4, restartY+ canH/12, sCircSizeControl, random(10,360), false); //stat canw vorher 10
  for (i = 0; i < obstacles.length; i++){
    obstacles[i].resetColor();
  }

  successcounter = 0;



} //destroyAndCreate END





function initObstacles(n){
    
    
     successHue = successHue+ random(-10,10);

  //let obstSize = thick*3;// 
  //for from testscript:
  for (i = 0; i < n; i++){
      
      let rando = Math.floor(random(0, obstacles.length-2));

 lastObstacle = obstacles[obstacles.length-1];
   // if(_success)  lastObstacle = obstacles[obstacles.length - rando ];
     
      
      //if(_success) lastObstacle = obstacles[0];

//if((lastObstacle.x >= canW || lastObstacle.x <= 0) && (lastObstacle.y >= canH ||lastObstacle.y <= 0) ) lastObstacle == obstacles[0]

/*
 let _boolXAdd = false;   
 let _boolYAdd = true; 
*/

//1. to make a normal shape 
//2. to not go over a certain border 

//1 to 2

//doesnt work on upper and lower 

if(lastObstacle.x < (canW/2) && lastObstacle.y < (canH/2)  ){
    
    //&& lastObstacle.y > (objectThick/2)
    
    _boolXAdd = true; _boolYAdd = false; 
    //if(_success){_boolXAdd = false; _boolYAdd = true; }
}

//2 to 3
if(lastObstacle.x > (canW/2) && lastObstacle.y < (canH/2)   ){
    
    //&& lastObstacle.x < (canW-objectThick/2) 
    
    _boolXAdd = true; _boolYAdd = true;  
    //if(_success){ _boolXAdd = false; _boolYAdd = false; }
}

//3 to 4
if(lastObstacle.x > (canW/2) && lastObstacle.y > (canH/2)  ){
    
    // && lastObstacle.y < (canH -objectThick/2)
    
    _boolXAdd = false; _boolYAdd = true; 
   // if(_success){_boolXAdd = true; _boolYAdd = false; }
}

//4 to 1
if(lastObstacle.x < (canW/2) && lastObstacle.y > (canH/2)  ){
    
    //&& lastObstacle.x > (objectThick/2)
    
    _boolXAdd = false; _boolYAdd = false; 
    //if(_success){_boolXAdd = true; _boolYAdd = true; }
}
      
    if(lastObstacle.x > canW) _boolXAdd = false;
    if(lastObstacle.y > canH) _boolYAdd = false;
     if(lastObstacle.x < 0) _boolXAdd = true;
    if(lastObstacle.y < 0) _boolYAdd = true;


      
let randoNumberX = random(objectThick*0.25, objectThick*1.1);
let randoNumberY = random(objectThick*0.25, objectThick*1.1);
      
      
      
/*
if(_boolXAdd){ //make value bigger
  xOff = +random(objectThick*0.3, objectThick*2);
}
else{ //make value smaller
  xOff = -random(objectThick*0.3, objectThick*2);
}


if(_boolYAdd){  //make value bigger
  yOff = +random(objectThick*0.3, objectThick*2);
}
else{ //make value smaller
  yOff = -random(objectThick*0.3, objectThick*2);
}
*/
    if(_boolXAdd){ //make value bigger
  xOff = +(randoNumberX+(degree*0.5)) //+(degree*0.5)
}
else{ //make value smaller
  xOff = -(randoNumberX+(degree*0.5)) //+degree
}


if(_boolYAdd){  //make value bigger
  yOff = +(randoNumberY+(degree*0.5)) //+degree
}
else{ //make value smaller
  yOff = -(randoNumberY+(degree*0.5)) //+degree
}
      

      
      


newOX= lastObstacle.x + xOff;
newOY= lastObstacle.y + yOff;
      

           

//if((newOX < canW || newOX > 0) && (newOY < canH || newOY > 0) && (newOX > ballCatcher.x/2 && newOY > ballCatcher.y/2 ) && (newOX != sCirc.x && newOY != sCirc.y)  ) //&& (newOX > restartX && newOY > restartY)

if((newOX != ballCatcher.x && newOY != ballCatcher.y ) && (newOX != sCirc.x && newOY != sCirc.y)  ) //&& (newOX > restartX && newOY > restartY)

{ 
    
    //
    
    obstacles.push(new Obstacle (newOX, newOY, random(objectThick*0.10, objectThick*0.25), 100, 1 ,obstacleBrightness++ )); 
    if(_success){  obstacles.push(new Obstacle (newOX, newOY, random(objectThick*0.05, objectThick*0.15), successHue, 100 ,70 )); }
}

  }//for END



console.log(obstacles.length);
}//init END
// Obstacle handling END




//--------------------------Keyshortcuts for debugging START
function keyPressed() {
  switch (key) {
          
   case "4": //toggle camerafeed
       _camVisualized = !_camVisualized;
       console.log(_camVisualized)
      break;
          
    case "5": //toggle head-sides
    _hideHelperDrawing = !_hideHelperDrawing;
     
      break;

   case "2": //refresh game
        console.log("refresh-button pressed")
      location.reload(true); //native js to refresh a page
      break;
          
    case "3": //close game
        console.log("close-button pressed")
      window.close(); //native js to close a page
      break;

     case "1": //go fullscreen
          
      document.documentElement.requestFullscreen(); //native js to close a page
      break;
          /*
          case "5":
      _mirroredMovement = !_mirroredMovement;
      break;
      */
    

  } //switch END
} //keyPressedFunction END
//--------------------------Keyshortcuts for debugging END






//DOC END

