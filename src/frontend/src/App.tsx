const  App = () => {

  const name : string = 'John Doe';
  const x : number = 10;
  const y : number = 10;
  const names = ['Brad', 'Mary', 'Joe', name];
  const logIn : boolean = true;
  const styles = {
    color : 'red',
    fontSize : '55px'
  };


  return (
    <>
      <div className="text-5xl">
        <p>Sum of {x} + {y} = {x + y} </p>
      </div>
      <div>
      <div style={styles}>
        <p> Hello: {name}</p>
      </div>
        <p>{logIn ? 'true' : 'false' } </p>
        {logIn &&  <p> Hello: {name}</p> } 
      </div>
      <div>
        <ul>
          {names.map((nam:string, index:number) =>
            <li key={index}> {nam}</li>
          )}
        </ul>
      </div>

    </>
  );
}

export default App;
