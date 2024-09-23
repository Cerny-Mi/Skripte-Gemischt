/*
//Contemplation corner:

[x]so I have the walls now...but why do they not push the ball at all????
You wannna know why??!?!??! Because I didnt add bodyL and bodyR to the world!!!!! without adding, their physics wont take action!!! T-T

*/


class Head {
  constructor(x, y, w) { //, h  //h wegnehmen, damit head automatisch gleichseitig ist!! sieht viel beser aus, bedient sich leichter!
    this.x = x;
    this.y = y;
    this.w = w;
    this.a = 0;
    //this.h = h;
    let options = {
      isStatic: true,
      isSensor: false,
      friction: 0.99,
      restitution: 0.01,
    }; //options END


    
    this.sideThickness = this.w/4;
    this.sideHeight = this.w+ (this.w/3);
    this.sideyOffset = -(this.w/4);
    //this.sideYOffset = -10; //matterjs doesnt seem to like it, because the physics dont react when i use it
    
    
    
    
    
    
    //----------------defining bodies START
    //middle:
    
    //rect version:
       this.body = Bodies.rectangle(this.x, this.y, this.w, this.w, options);
    
  
    
    //how do I make it so that the helpers start exactly where the .... i just position them up a bit T-T
    
    //links:
      this.bodyL = Bodies.rectangle(this.x - (this.w/2), this.y+ this.sideyOffset, this.sideThickness, this.sideHeight, options); 
    
    //rechts:
      this.bodyR = Bodies.rectangle(this.x + (this.w/2), this.y+ this.sideyOffset, this.sideThickness, this.sideHeight, options); 
    //----------------defining bodies END
   
    
    
    this.body.label = "head";
    //this.bodyL.label = "head";
    //this.bodyR.label = "head";
    
    
    
    //----------------adding to world ****** START
    World.add(world, this.body); 
    World.add(world, this.bodyL); 
    World.add(world, this.bodyR); 
    //----------------adding to world ****** END
    
    
    
    
  } //const END

  
  //!
  updatePosition(inputX, inputY) {



    //console.log("div: "+div);

    
    
    //version with canW - myOriginalValue ---> worked!!!! now the matterkjs is reacting normally again!!! T-T ugly tears
    //matter
  
      //so that head behaves "normally"
      let flippedVec = createVector(canW-inputX, inputY);
      let flippedVecL = createVector(canW-(inputX- (this.w/2)), inputY+ this.sideyOffset);
      let flippedVecR = createVector(canW-(inputX+ (this.w/2)), inputY+ this.sideyOffset);
      
      
      //so that head behaves originally
      let Vec = createVector(inputX, inputY);
      let VecL = createVector(inputX- (this.w/2), inputY+ this.sideyOffset);
      let VecR = createVector(inputX+ (this.w/2), inputY+ this.sideyOffset);

      /*
      let VecL = createVector(inputX+ (this.w/2), inputY);
      let VecR = createVector(inputX- (this.w/2), inputY);
      
      */
      
      if(!_mirroredMovement)
      { 
    
     Matter.Body.setPosition(this.body, flippedVec);
     Matter.Body.setPosition(this.bodyL, flippedVecL);
     Matter.Body.setPosition(this.bodyR, flippedVecR);
      
      } //ifNotMirrored END
      
      
      
      if(_mirroredMovement){
     
     Matter.Body.setPosition(this.body, Vec);
     Matter.Body.setPosition(this.bodyL, VecL);
     Matter.Body.setPosition(this.bodyR, VecR);
        
        
      }
    
    
    
 //------------draw p5-stuff: 
    
    //rect:
     push();
    
    let pos = this.body.position;
     translate(pos.x, pos.y); //or directly asks for the body properties
   rectMode(CENTER);


    noStroke();
    colorMode(HSB);
   if(chosenColor == "yellow") fill(61, 100, 90);
   else if (chosenColor =="cyan") fill(200, 100, 90);
    // let rMiddle = triangle(0- (this.w/2) ,this.w/2,  this.w/2, this.w/2, 0, 0-(this.w/2));
    let rMiddle = rect(0, 0 , this.w, this.w); 
  

    //text to display success counter:

   
    
    fill(100);
    noStroke();
    textSize(this.w/2);
    //content, x, y
    textAlign(CENTER);
    text(successcounter, 0,this.w/6);
   


    
if(_hideHelperDrawing ==false){
      
fill(153, 100,100);
let rLeft =  rect(0- (this.w/2), 0+ this.sideyOffset, this.sideThickness, this.sideHeight);

fill(255, 100, 100);
let rRight = rect(0+ (this.w/2), 0 + this.sideyOffset, this.sideThickness, this.sideHeight);

} //ifhidehelper END
//does it recognize the bool from sketch?? yes, it does!!! :D
    
     } //updatePos END
  
  
  

  
  
  
} //class END
