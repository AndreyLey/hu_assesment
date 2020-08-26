import React from 'react';
import { shallow } from 'enzyme';
import FormSummary from './FormSummary';

describe('FormSummary', () => {
  test('matches snapshot', () => {
    const wrapper = shallow(<FormSummary />);
    expect(wrapper).toMatchSnapshot();
  });
});
