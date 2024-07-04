'use client'
import { useState } from "react"
import { getRed, getGreen, getBlue } from "../_utils/clientApi/getColours"
import { getDouble } from "../_utils/clientApi/getSlider";

export default function Picker() {
  const defaultSliderVal = 10;
  const defaultBgCol = "#E2E2E2"
  
  const [colorState, setColorState] = useState(defaultBgCol);
  const [sliderVal, setSliderVal] = useState(defaultSliderVal);
  const [doubledVal, setDoubledVal] = useState(defaultSliderVal * 2);

  const handle1 = async () => {
    const red = await getRed();
    setColorState(red);
  }
  const handle2 = async () => {
    const green = await getGreen();
    setColorState(green);
  }
  const handle3 = async () => {
    const blue = await getBlue();
    setColorState(blue);
  }
  const updateSlider = async (val: number) => {
    setSliderVal(val)
    const doubled = await getDouble(val);
    setDoubledVal(doubled);
  }

  return (
    <div className="flex flex-col gap-10 items-center">
      <div className="flex flex-row gap-4" >
        <button onClick={handle1} className="bg-purple-400 p-2 rounded-lg">1</button>
        <button onClick={handle2} className="bg-purple-400 p-2 rounded-lg">2</button>
        <button onClick={handle3} className="bg-purple-400 p-2 rounded-lg">3</button>
      </div>
      <div className="flex flex-row-reverse justify-between w-40">
        <div className="mx-auto">{sliderVal}</div>
        <input type="range" onChange={(event) => {updateSlider(Number(event.target.value))}} defaultValue={sliderVal}></input>
      </div>
      <div className="p-4 rounded w-full text-center" style={{backgroundColor: colorState}}>
        <span className="mix-blend-difference ">{doubledVal}</span>
      </div>
    </div >
  )
}