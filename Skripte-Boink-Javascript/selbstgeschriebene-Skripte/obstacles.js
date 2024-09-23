class Obstacle {
  constructor(x, y, r, h = 100, s = 1, b = 50) {

    //default col values: 100, 1 ,50
    this.x = x;
    this.y = y;
    this.r = r;
    this.h = h; //hue
    this.s = s; //saturation
    this.b = b; //brightness
    colorMode(HSB, 360, 100, 100); // Switch to HSB mode

    let options = {
      friction: 0.5, //val between 0 and 1
      restitution: 0,
      isStatic: true,
     // density: 1,
      frictionAir: 0.05 , //default =0.01
      isSensor: false,
    
    };

    let options2 = {
      friction: 0, //val between 0 and 1
      restitution: 0,
      isStatic: true,
     // density: 1,
      frictionAir: 0,  //default =0.01
      isSensor: true, //this means that it will not shove the ball away, only register a collision
    
    };

  


    //this.body = Bodies.circle(this.x, this.y, this.r, options); 
    this.body = Bodies.rectangle(this.x, this.y, this.r*1.3, this.r*1.3, options);  //*1.8
    this.body.label = "obstacle";
    


    //the double only for decting passing
    //doesnt need to be drawn, only needs to get asked for collision
    this.body2 = Bodies.rectangle(this.x, this.y, this.r*6, this.r*6, options2); 
    this.body2.label = "pass";
    this.body2.color = color(this.h,this.s,this.b);
 
    


   
    
    //Composite.add(world, this.body);
    World.add(world, this.body); 
    World.add(world, this.body2); 


  } //const END

  show() {

    
    let pos = this.body.position;
    let col = this.body2.color;

    push();
    
    translate(pos.x, pos.y);
    colorMode(HSB, 360, 100, 100); // Switch to HSB mode
    fill(col);
    //fill(this.h, this.s, this.b);
    noStroke();
    angleMode(DEGREES);
    rectMode(CENTER);
   if(successcounter < 5 || successcounter > 10) degree = degree+0.001;
      if(successcounter >= 5) degree = degree-0.001;
    rotate(degree);
    rect(0, 0, this.r * 2, this.r * 2);
    pop();

    //console.log(degree);

    if(degree >= 360) degree = 1;
       if(degree <= 0) degree = 359;

  } //show END

  removeFromWorld() {
    World.remove(world, this.body);
  } //remove END

resetColor(){

  //hue, saturation, brightness
  this.h = 100; this.s = 1; this.b =50;
  this.body2.color = color(this.h,this.s,this.b);
}



successColoring(hue){
//hue, saturation, brightness

//headColor = color(51, 100, 51);

this.h = successHue; this.s = 100; this.b =100;
  this.body2.color = color(this.h,this.s,this.b);


}






} //class END





