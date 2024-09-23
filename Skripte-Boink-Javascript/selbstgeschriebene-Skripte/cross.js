/*
//Contemplation corner:

*/


class Cross {
  constructor(x, y, name= 'you forgot to name this cross, loser', _isACircle = false) {
    this.x = x;
    this.y = y;
    this.name = name; //only in here to make the switch-case of the detection a biiiit easier
    this._isACircle = _isACircle
    
    
    
  let r = random(1,255);
    let g = random(1,255);
    let b = random(1,255);
  let c =  color(r,g,b);
    
    this.c = c;
    
    
    

  } //const END

  
  //!
  show() {
    
    //why a seperate class? becazse if i want to change the cross-pos, i can say that ONCE in setup. and never again. means less editing.
    
    //and also i can summon different crosses, whose... crossing... can later be used to replace key-getting! aka crosses instead of keys!
    
    
    //renders it in draw, to make it visible every frame
    
   //draw at the end so that you can see it OVER the head-shape
  //showing the vecRestart-position as lines in draw:
    
  stroke(this.c);
    
    
    if(!this._isACircle)
{  strokeWeight(5);
  line(this.x-5,this.y-5,this.x+5,this.y+5);
  line(this.x+5,this.y-5,this.x-5,this.y+5);
  }  
    
    
    if(this._isACircle){
      stroke(255);
      strokeWeight(1.5);
      noFill();
      ellipse(this.x, this.y, 20);
      
    }
    
    
     } //show END
  
  
  

  
  
  
} //class END
