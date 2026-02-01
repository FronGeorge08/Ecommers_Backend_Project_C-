import { useState } from "react";

const Component = () => {
    const [incrementer,setIncrementer]= useState(0) 
    function Increment() {
        setIncrementer(incrementer+1)
    }
    function Decrement() {
        setIncrementer(incrementer-1)
    }

    return (
        <div
            style={{
                position: "relative",
                top: "20 rem"
            }}>
            <button onClick={Increment}>Increment</button>
            <p>{incrementer}</p>
            <button onClick={Decrement}>Decrement</button>
        </div>
    );
};


export default Component