import React from 'react';
import { shallow } from 'enzyme';
import FormSummary from './FormBuilder';

describe('FormBuilder', () => {
  test('matches snapshot', () => {
    const wrapper = shallow(<FormSummary />);
    expect(wrapper).toMatchSnapshot();
  });
});
