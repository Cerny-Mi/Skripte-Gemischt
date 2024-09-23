function decideHeadPosition(firstx, firsty, threshhold ){
  
  /*
  //goal of this function:
  if the input given (firstpx.x and firstpx.y) isn't far away from the last value (aka doesnt breach a certain threshhold), then the head is put to that firstpx-position and the last value and middle value are updated. 
  if it breaches the value, lerp between the last value and the middle value and position the head there
  
  //necessary tasks for this function
  [x]1. define the arrays for last, middle and new value
  [x]2. check if the new value is breaching
  [x]3. if not breaching, update headposition with the new value and update oldest and middle value
  [x]4. if breaching, update headposition with a lerp-value of oldest and middle

//source for lerp: https://p5js.org/reference/#/p5.Vector/lerp
  
  */
  
  
    //save positions into an array:
    nPos = createVector(firstx, firsty, 0);
  if(mPos == undefined) mPos = oPos;
  
  //theoretically, i dont need the stash. but i'll leave it in just in case.
    headPositionStash[0] = oPos; //opos had been defined in setups of sketch.js. does its value carry over to this function?
    headPositionStash[1] = mPos; //will be defined later
    headPositionStash[2] = nPos;//was defined above
  


//threshold for nPos:    
        if (
        nPos.x <= oPos.x + threshhold &&
        nPos.x >= oPos.x - threshhold &&
        nPos.y <= oPos.y + threshhold &&
        nPos.y >= oPos.y - threshhold
      ) {
          
          //if the new value is usable because no bounds are breached:
       oPos = mPos; //old position gets updated
       mPos = nPos; //midle position gets updated
       _newValueUsable= true;  
       
      } //if nPos didnt breach END
      else{
        
        //opo-mpos-veränderungen müssen so bleiben, denn sonst flackert der kopf zu wild. no good.
        //lets make a good thing out of the inconvenience (that head stops if user too fast).
      //  oPos = mPos;
       // mPos = nPos;
        
        
      _newValueUsable= false;  
        
          } //if npos breached END
      
      
      
    
//////aftermath: 
      
  if(_newValueUsable)
  {//if no breaching: update headposition with given values:
  
    durchschnitt = p5.Vector.lerp(oPos, nPos, 0.6);
   // durchschnitt = p5.Vector.lerp(oPos, mPos, 0.8);
     myHead.updatePosition(durchschnitt.x, durchschnitt.y, headColor);
     oPos = mPos; //old position gets updated
     mPos = nPos; //midle position gets updated
   //myHead.updatePosition(firstx, firsty, headColor);
  }//if END
   


  
  if(!_newValueUsable)
  {//if breaching:  update headposition with lerped values:
    
    //console.log("breached!");


    /*

 durchschnitt = p5.Vector.lerp(oPos, mPos, 0.1);
    
   colorMode(HSB, 360, 100,100)
    //lerp-amount-value: 0.0 is equal to the first point, 0.1 is very near the first point, 0.5 is half-way in between, and 1.0 is equal to the second point.
    let standingColor = color(51, 99, 51); //  headColor = color(51, 100, 51);
  myHead.updatePosition(durchschnitt.x, durchschnitt.y, standingColor);



     */
  



  }//if! END

  
  


  
}//complete function END