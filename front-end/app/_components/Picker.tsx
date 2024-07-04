'use client'
import { useState } from "react"
import getRed from "../_utils/clientApi/getColours"

export default function Picker() {
  const [state, setState] = useState(0)
  const handle1 = async () => {
    setState(1)
    const red = await getRed();
    alert(red);
  }
  const handle2 = () => {
    setState(2)
  }
  const handle3 = () => {
    setState(3)
  }
  return (
    <>
    <div className="flex flex-row gap-4" >
      <button onClick={handle1} className="bg-purple-400 p-2 rounded-lg">1</button>
      <button onClick={handle2} className="bg-purple-400 p-2 rounded-lg">2</button>
      <button onClick={handle3} className="bg-purple-400 p-2 rounded-lg">3</button>

    </div>
    <div>State: {state}</div>
    </>
  )
}