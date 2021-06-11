import { Steps, Step } from 'react-step-builder'

const Navigation = props => (
  <div>
    <button onClick={props.prev}>Previous</button>
    <button onClick={props.next}>Next</button>
  </div>
)

const Purchase = props => {
  return (
    <main>
      <Steps config={{ navigation: { component: Navigation, location: "before" } }}>
        <Step title="My First Step" component={() => <h1>Step1</h1>} />
        <Step title="My Second Step" component={() => <h1>Step2</h1>} />
        <Step title="My Third Step" component={() => <h1>Step3</h1>} />
      </Steps>
    </main>
  )
}

export default Purchase